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
            //CreateMap<CreatorUpdateAppointment, Appointment>().ReverseMap();

            CreateMap<CreatorUpdateAppointment, Appointment>()
           .ForMember(dest => dest.BookngTime, opt => opt.MapFrom(src => src.Time))
           .ReverseMap()
           .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.BookngTime));



            CreateMap<GetAllAppointement, Appointment>().ReverseMap();
            CreateMap<CreatorUpdateDoctor, Doctor>().ReverseMap();
            CreateMap<GetAllDoctors, Doctor>().ReverseMap();
         //   CreateMap<GetAllReviewsDto, Review>().ReverseMap();
            //CreateMap<CreatorUpdatePatient, Patient>().ReverseMap();


            CreateMap<CreatorUpdatePatient, Patient>()
         .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == Gender.Male ? false : true))
         .ReverseMap()
         .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ? Gender.Female : Gender.Male));

            CreateMap<GetAllPatients, Patient>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == Gender.Male ? false : true))
                .ReverseMap()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ? Gender.Female : Gender.Male));

            CreateMap<GetAllReviewsDto, Review>().ReverseMap();
            CreateMap<CreateUpdateReviews, Review>().ReverseMap();

            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserLoginInfo, User>().ReverseMap();
            CreateMap<RegisterDTO, CreatorUpdateDoctor>().ReverseMap();
            CreateMap<RegisterDTO, User>().ReverseMap();





        }
    }
}
