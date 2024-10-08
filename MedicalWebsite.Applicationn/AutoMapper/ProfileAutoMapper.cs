
using AutoMapper;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Booking;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.Review;
using MedicalWebsite.Models.Models;
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
           

            //CreateMap<CreatorUpdatePatient, Patient>().ReverseMap();
            //CreateMap<GetAllPatients, Patient>().ReverseMap();

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

        }
}
}
