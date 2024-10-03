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
            CreateMap<GetAllReviewsDto, Review>().ReverseMap();
            CreateMap<CreatorUpdatePatient, Patient>().ReverseMap();

           
        }
    }
}
