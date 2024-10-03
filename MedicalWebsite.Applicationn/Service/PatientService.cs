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
using Vezeeta.Application.Iservices;

namespace MedicalWebsite.Applicationn.Service
{
    public class PatientService//:IPatientService
    {
        private readonly IpatientRepository _patientReposatory;
        private readonly IMapper _mapper;
        public PatientService(IpatientRepository patientReposatory, IMapper mapper)
        {
            _patientReposatory = patientReposatory;
            _mapper = mapper;
        }

       
      
    }
}
