using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Appointment;
using Microsoft.AspNetCore.Identity;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using Microsoft.EntityFrameworkCore;

namespace MedicalWebsite.Applicationn.Service
{
    public class PatientService:IPatientService
    {
        private readonly IUserService _userService;
        private readonly IpatientRepository _patientReposatory;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        public PatientService(SignInManager<User> signInManager,IEmailSender emailSender, UserManager<User> userManager, IUserService userService,IpatientRepository patientReposatory, IMapper mapper)
        {
            _patientReposatory = patientReposatory;
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
        }

        public async Task<ResultView<CreatorUpdatePatient>> BlockPatient(string PatientId)
        {
            try
            {
                var patient = await _patientReposatory.GetByIdAsync(PatientId);
                if (patient == null)
                {
                    return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "This Patient is not found" };

                }
                else
                {
                    patient.IsDeleted = true;
                    await _patientReposatory.SaveChangesAsync();

                    var TopicDto = _mapper.Map<CreatorUpdatePatient>(patient);
                    return new ResultView<CreatorUpdatePatient> { Entity = TopicDto, IsSuccess = true, Message = "Blocked " };

                }
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = ex.Message };

            }
        }

        public  Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            return _userService.ConfirmEmailAsync(userId, token);
        }


        public async Task<ResultDataList<GetAllPatients>> GetAllPatientsPages(int items, int pagenumber)
        {
            var Alldata = (await _patientReposatory.GetAllAsync()).Where(c => (bool)!c.IsDeleted)
                            .ToList(); ;

            if (Alldata == null)
            {
                return new ResultDataList<GetAllPatients>
                {
                    Entities = null,
                    Count = 0

                };
            }
            var userlist =  Alldata.Skip(items * (pagenumber - 1)).Take(items).Select(p => new GetAllPatients()
            {
                Id=p.Id,
                Address = p.Address,
                UserName = p.UserName,
                Gender = p.Gender ? Gender.Male : Gender.Female,
                Phone = p.Phone,
                insurance= p.insurance,
                Email=p.Email

            }).ToList();

            //return new ResultDataList<GetAllPatients>
            //{
            //    Entities = userlist,
            //    Count = userlist.Count(),
            //    CurrentPage = pagenumber,
            //    PageSize = items,
            //};


            var totalItems = Alldata.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / items);

            var resultDataList = new ResultDataList<GetAllPatients>
            {
                Entities = userlist,
                Count = totalItems,
                TotalPages = totalPages,
                CurrentPage = pagenumber,
                PageSize = items
            };

            return resultDataList;
        }

        public async Task<ResultDataList<GetAllPatients>> GetBlockedPatients(int items, int pagenumber)
        {
            try
            {
                var blockedPatients = (await _patientReposatory.GetAllAsync())
                                      .Where(p => p.IsDeleted==true)
                                      .Select(p => new GetAllPatients
                                      {
                                          Id = p.Id,
                                          Address = p.Address,
                                          UserName = p.UserName,
                                          Gender = p.Gender ? Gender.Male : Gender.Female,
                                          Phone = p.Phone,
                                          insurance = p.insurance,
                                          Email = p.Email
                                      })
                                      .ToList();

                return new ResultDataList<GetAllPatients>
                {
                    Entities = blockedPatients,
                    Count = blockedPatients.Count,
                    //IsSuccess = true,
                    //Message = "Blocked patients retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultDataList<GetAllPatients>
                {
                    Entities = null,
                    Count = 0,
                    //IsSuccess = false,
                    //Message = ex.Message
                };
            }
        }

      
        public async Task<ResultView<CreatorUpdatePatient>> GetPatientById(string id)
        {
            try
            {
                var patient = await _patientReposatory.GetByIdAsync(id);
                if (patient == null)
                {
                    return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "patient is not found" };

                }
                var patientDto = _mapper.Map<CreatorUpdatePatient>(patient);
                return new ResultView<CreatorUpdatePatient> { Entity = patientDto, IsSuccess = true, Message = "patient found Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "Something went wrong" };
            }
        }

      
        public async Task<ResultView<CreatorUpdatePatient>> HardDeletePatient(string id)

        {
            try
            {
                var patient = await _patientReposatory.GetByIdAsync(id);
                if (patient == null)
                
                    return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "patient is not Found" };

                await _patientReposatory.DeleteAsync(patient);
                await _patientReposatory.SaveChangesAsync();

                var deletedpatientDto = _mapper.Map<CreatorUpdatePatient>(patient);
                return new ResultView<CreatorUpdatePatient>
                {
                    Entity = deletedpatientDto,
                    IsSuccess = true,
                    Message = "patient deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = ex.Message };

            }
        }

        public async Task<ResultView<CreatorUpdatePatient>> LoginAsPatient(string id)
        {
            var user = (await _patientReposatory.GetByIdAsync(id));
            var patientto = _mapper.Map<UserLoginDTO>(user);
            var patient = await _userService.LoginAsync(patientto);
            if (patient.IsSuccess)
            {
                var npatient = _mapper.Map<CreatorUpdatePatient>(patient);
                var res = new ResultView<CreatorUpdatePatient>() { IsSuccess = true, Entity = npatient, Message = "Successfully Login" };
                return res;
            }

            return new ResultView<CreatorUpdatePatient>() { IsSuccess = true, Entity = null, Message = "Failed to Login" }; ;
        }

       
        public async Task<ResultView<CreatorUpdatePatient>> RegisterAsPatient(CreatorUpdatePatient account)
        {


            try
            {
                var exitingUser = await _userManager.FindByEmailAsync(account.Email);
                if (exitingUser == null)
                {
                    //var NewUser = new Patient
                    //{
                    //    Email = account.Email,
                    //    UserName = account.UserName,
                    //    PhoneNumber = account.Phone,
                    //    Adress = account.Adress,
                    //    Birthdate = account.BirthDate,
                    //    //Gender = account.Gender,
                    //    //Gender = account.Gender ? Gender.Female : Gender.Male,
                    //    //Education = account.Education,
                    //    //SpecializationId = (Guid)account.SpecializationId,
                    //    // EmailConfirmed = true
                    //};
                    var NewUser = new Patient
                    {
                        Email = account.Email,
                        UserName = account.UserName,
                        PhoneNumber = account.Phone,  
                        Phone = account.Phone,        
                        Address = account.Address,
                        Birthdate = account.BirthDate,
                        // Gender = account.Gender == Gender.Female,
                        Gender = account.Gender == Gender.Male,

                        //  Gender = account.Gender ? Gender.Female : Gender.Male,
                        insurance = account.insurance
                    };

                    var result = await _userManager.CreateAsync(NewUser, account.password);


                    if (result.Succeeded)
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);
                        var confirmationLink = $"http://localhost:5029/api/Doctor/confirm-email?userId={NewUser.Id}&token={Uri.EscapeDataString(token)}";

                        // Send the email
                        await _emailSender.SendEmailAsync(NewUser.Email, "Confirm your email",
                            $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>");

                        await _userManager.AddToRoleAsync(NewUser, "PATIENT");

                        var registeredUserDto = _mapper.Map<CreatorUpdatePatient>(NewUser);
                        return new ResultView<CreatorUpdatePatient>()
                        {
                            Entity = registeredUserDto,
                            IsSuccess = true,
                            Message = "User registered successfully."
                        };
                    }
                    else
                    {
                        var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
                        return new ResultView<CreatorUpdatePatient>()
                        {
                            Entity = null,
                            IsSuccess = false,
                            Message = $"Failed to register user. Error: {errorMessages}"
                        };
                        //return new ResultView<CreatorUpdatePatient>()
                        //{
                        //    Entity = null,
                        //    IsSuccess = false,
                        //    Message = $"Failed to register user. Error: {string.Join(", ", result.Errors)}"
                        //};
                    }
                }
                return new ResultView<CreatorUpdatePatient>()
                {
                    Entity = account,
                    IsSuccess = false,
                    Message = "User already exists"
                };

            }
            catch (Exception e)
            {
                return new ResultView<CreatorUpdatePatient>()
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "An unexpected error occurred during registration."
                };
            }
        }

        public async Task<ResultView<CreatorUpdatePatient>> UpdatePatient(GetAllPatients PatientDto)
        {
            ResultView<CreatorUpdatePatient> result = new();
            try
            {
                var oldTopic = (await _patientReposatory.GetAllAsync()).AsNoTracking()
                    .FirstOrDefault(t => t.Id == PatientDto.Id);
                
                if (oldTopic == null)
                {
                    result.IsSuccess = false;
                    result.Entity = null;
                    result.Message = "patient is not found";
                    return result;
                }
                var Ntopic = _mapper.Map<Patient>(PatientDto);
                var Newtopic = await _patientReposatory.UpdateAsync(Ntopic);
                await _patientReposatory.SaveChangesAsync();
                var NewTopicDto = _mapper.Map<CreatorUpdatePatient>(Newtopic);
                result.Entity = NewTopicDto;
                result.IsSuccess = true;
                result.Message = "Your Data Updated Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Entity = null;
                result.Message = "Something went wrong";
                return result;

            }
        }
    }

       

    
}
