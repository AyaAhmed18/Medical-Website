using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IUserService _userService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IUserService userService, IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public Task<ResultView<CreatorUpdateDoctor>> BlockDoctor(string DoctorId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            return _userService.ConfirmEmailAsync(userId, token);
        }

        public Task<ResultDataList<GetAllDoctors>> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultView<CreatorUpdateDoctor>> GetDoctorById(string id)
        {
            try
            {
                var Doctor = await _doctorRepository.GetByIdAsync(id);
                if (Doctor == null)
                {
                    return new ResultView<CreatorUpdateDoctor> { Entity = null, IsSuccess = false, Message = "Doctor is not found" };

                }
                var DoctorDto = _mapper.Map<CreatorUpdateDoctor>(Doctor);
                return new ResultView<CreatorUpdateDoctor> { Entity = DoctorDto, IsSuccess = true, Message = "Doctor found Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateDoctor> { Entity = null, IsSuccess = false, Message = "Something went wrong" };
            }
        }

        public Task<ResultDataList<GetAllDoctors>> GetDoctorsBy()
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataList<GetAllDoctors>> GetDoctorsBySpecialization()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultView<CreatorUpdateDoctor>> HardDeleteDoctor(CreatorUpdateDoctor DoctorDto)
        {
            try
            {
                var Doctor = await _doctorRepository.GetByIdAsync(DoctorDto.Id);
                if (Doctor == null)
                {
                    return new ResultView<CreatorUpdateDoctor> { Entity = null, IsSuccess = false, Message = "Doctor is not Found" };

                }
                else
                {
                    var oldDoctor = _doctorRepository.DeleteAsync(Doctor);
                    await _doctorRepository.SaveChangesAsync();
                    var oDoctorDto = _mapper.Map<CreatorUpdateDoctor>(oldDoctor);
                    return new ResultView<CreatorUpdateDoctor> { Entity = oDoctorDto, IsSuccess = true, Message = "Deleted Successfully" };

                }
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateDoctor> { Entity = null, IsSuccess = false, Message = ex.Message };

            }
        }

        public Task<CreatorUpdateDoctor> LoginAsDoctor(CreatorUpdateDoctor DoctorDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultView<RegisterDTO>> RegisterAsDoctor(RegisterDTO DoctorDto)
        {
            
            var NewDoctor = await _userService.Registration(DoctorDto, "DOCTOR");
            return NewDoctor;
        }

        public async Task<ResultView<CreatorUpdateDoctor>> UpdateDoctor(CreatorUpdateDoctor DoctorDto)
        {
            ResultView<CreatorUpdateDoctor> result = new();
            try
            {
                var oldTopic = (await _doctorRepository.GetAllAsync()).AsNoTracking()
                    .FirstOrDefault(t => t.Id == DoctorDto.Id);
                // var oldTopic = (await _topicRepository.GetByIdAsync(topic.Id));


                if (oldTopic == null)
                {
                    result.IsSuccess = false;
                    result.Entity = null;
                    result.Message = "Doctor is not found";
                    return result;
                }
                var Ntopic = _mapper.Map<Doctor>(DoctorDto);
                var Newtopic = await _doctorRepository.UpdateAsync(Ntopic);
                await _doctorRepository.SaveChangesAsync();
                var NewTopicDto = _mapper.Map<CreatorUpdateDoctor>(Newtopic);
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
