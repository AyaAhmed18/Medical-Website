using AutoMapper;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Booking;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.Review;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.AutoMapper
{
    public class ProfileAutoMapper:Profile
    {
        public ProfileAutoMapper() 
        {
            CreateMap<CreatorUpdateAppointment, Appointment>().ReverseMap();
            CreateMap<GetAllAppointement, Appointment>().ReverseMap();
            CreateMap<CreatorUpdateDoctor, Doctor>().ReverseMap();
            CreateMap<GetAllDoctors, Doctor>().ReverseMap();
            CreateMap<GetAllReviewsDto, Review>().ReverseMap();
            CreateMap<CreatorUpdatePatient, Patient>().ReverseMap();


            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserLoginInfo, User>().ReverseMap();
            CreateMap<RegisterDTO, CreatorUpdateDoctor>().ReverseMap();
            CreateMap<RegisterDTO, User>().ReverseMap();


        }
    }
}
