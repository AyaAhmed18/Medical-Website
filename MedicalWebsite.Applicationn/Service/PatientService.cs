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
            var Alldata = (await _patientReposatory.GetAllAsync());
            if (Alldata == null)
            {
                return new ResultDataList<GetAllPatients>
                {
                    Entities = null,
                    Count = 0

                };
            }
            var userlist = await Alldata.Skip(items * (pagenumber - 1)).Take(items).Select(p => new GetAllPatients()
            {
                Id=p.Id,
                Adress = p.Adress,
                UserName = p.UserName,
                Gender = p.Gender ? Gender.Male : Gender.Female,
                Phone = p.Phone,
                insurance= p.insurance,
                Email=p.Email

            }).ToListAsync();
            //  var userDTOs = _mapper.Map<List<GetAllDoctors>>(userlist);

            return new ResultDataList<GetAllPatients>
            {
                Entities = userlist,
                Count = userlist.Count(),
                CurrentPage = pagenumber,
                PageSize = items
            };
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
                {
                    return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "patient is not Found" };

                }
                else
                {
                    var oldpatient = _patientReposatory.DeleteAsync(patient);
                    await _patientReposatory.SaveChangesAsync();
                    var newpatientDto = _mapper.Map<CreatorUpdatePatient>(oldpatient);
                    return new ResultView<CreatorUpdatePatient> { Entity = newpatientDto, IsSuccess = true, Message = "Deleted Successfully" };

                }
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

        //public async Task<ResultView<RegisterDTO>> RegisterAsPatient(RegisterDTO PatientDto)
        //{

        //    var NewPatient = await _userService.Registration(PatientDto, "PATIENT");
        //    return NewPatient;
        //}
       
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
                        //Id= account.Id,
                        Email = account.Email,
                        UserName = account.UserName,
                        PhoneNumber = account.Phone,  
                        Phone = account.Phone,        
                        Adress = account.Adress,
                        Birthdate = account.BirthDate,
                        Gender = account.Gender == Gender.Female,
                        //Gender = account.Gender ? Gender.Female : Gender.Male,
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

        //public async Task<ResultView<CreatorUpdatePatient>> Create(CreatorUpdatePatient patient)
        //{
        //    var Query = (await _patientReposatory.GetAllAsync());
        //    var Oldpatient = Query.Where(App => App.Id == patient.Id).FirstOrDefault();

        //    if (Oldpatient != null)
        //    {
        //        return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "Already Exist" };
        //    }
        //    else
        //    {
        //        var thepatient = _mapper.Map<Patient>(patient);
        //        var Newpatient = await _patientReposatory.CreateAsync(thepatient);
        //        await _patientReposatory.SaveChangesAsync();
        //        var patientDto = _mapper.Map<CreatorUpdatePatient>(Newpatient);
        //        return new ResultView<CreatorUpdatePatient> { Entity = patientDto, IsSuccess = true, Message = "Created Successfully" };
        //    }

        //}

        //public async Task<ResultDataList<GetAllPatients>> GetAllPagination(int items, int pagenumber)
        //{
        //    var AlldAta = (await _patientReposatory.GetAllAsync());
        //    var activePatient = AlldAta.Where(p => p.IsDeleted == false);
        //    var patients = activePatient
        //        .Skip(items * (pagenumber - 1))
        //        .Take(items)
        //        .Select(p => new GetAllPatients()
        //        {
        //            Id = p.Id,
        //            Name = p.UserName,
        //            BirthDate = p.Birthdate,
        //            phoneNumber = p.PhoneNumber,
        //            Gender = p.Gender ? Gender.Male : Gender.Female,
        //           // Gender = p.Gender.HasValue ? (p.Gender.Value ? Gender.Male : Gender.Female) : (Gender?)null


        //        })
        //        .ToList();

        //    var totalItems = AlldAta.Count(c => c.IsDeleted == false);
        //    var totalPages = (int)Math.Ceiling((double)totalItems / items);

        //    var resultDataList = new ResultDataList<GetAllPatients>()
        //    {
        //        Entities = patients,
        //        Count = totalItems,
        //        TotalPages = totalPages,
        //        CurrentPage = pagenumber,
        //        PageSize = items

        //    };


        //    return resultDataList;
        //}

        //public async Task<GetAllPatients> GetOne(string ID)
        //{
        //    var onePatient = await _patientReposatory.GetByIdAsync(ID);
        //    var Patient = _mapper.Map<GetAllPatients>(onePatient);
        //    return Patient;
        //}

        //public async Task<int> SaveShanges()
        //{
        //    return await _patientReposatory.SaveChangesAsync();
        //}

        //public async Task<ResultView<GetAllPatients>> SoftDelete(GetAllPatients patient)
        //{
        //    try
        //    {
        //        var patientm = _mapper.Map<Patient>(patient);
        //        var Oldpatient = (await _patientReposatory.GetAllAsync()).FirstOrDefault(p => p.Id == patient.Id);
        //        Oldpatient.IsDeleted = true;
        //        await _patientReposatory.SaveChangesAsync();
        //        var patientDto = _mapper.Map<GetAllPatients>(Oldpatient);
        //        return new ResultView<GetAllPatients> { Entity = patientDto, IsSuccess = true, Message = "Deleted Successfully" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<GetAllPatients> { Entity = null, IsSuccess = false, Message = ex.Message };
        //    }
        //}

        //public async Task<ResultView<CreatorUpdatePatient>> Update(CreatorUpdatePatient patient)
        //{
        //    // throw new NotImplementedException();
        //    try
        //    {
        //        var Data = await _patientReposatory.GetByIdAsync(patient.Id);

        //        if (Data == null)
        //        {
        //            return new ResultView<CreatorUpdatePatient> { Entity = null, IsSuccess = false, Message = "Appointment Not Found!" };

        //        }
        //        else
        //        {
        //            var patientt = _mapper.Map<Patient>(patient);
        //            var patienttEdit = await _patientReposatory.UpdateAsync(patientt);
        //            await _patientReposatory.SaveChangesAsync();
        //            var paDto = _mapper.Map<CreatorUpdatePatient>(patienttEdit);

        //            return new ResultView<CreatorUpdatePatient> { Entity = paDto, IsSuccess = true, Message = "Status Updated Successfully" };
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreatorUpdatePatient>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"Something went wrong: {ex.Message}"
        //        };
        //    }
        //}



    
}
