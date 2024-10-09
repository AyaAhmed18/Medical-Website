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

namespace MedicalWebsite.Applicationn.Service
{
    public class PatientService:IPatientService
    {
        private readonly IpatientRepository _patientReposatory;
        private readonly IMapper _mapper;
        public PatientService(IpatientRepository patientReposatory, IMapper mapper)
        {
            _patientReposatory = patientReposatory;
            _mapper = mapper;
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

        public async Task<ResultDataList<GetAllPatients>> GetAllPagination(int items, int pagenumber)
        {
            var AlldAta = (await _patientReposatory.GetAllAsync());
            var activePatient = AlldAta.Where(p => p.IsDeleted == false);
            var patients = activePatient
                .Skip(items * (pagenumber - 1))
                .Take(items)
                .Select(p => new GetAllPatients()
                {
                    Id = p.Id,
                    Name = p.UserName,
                    BirthDate = p.Birthdate,
                    phoneNumber = p.PhoneNumber,
                    Gender = p.Gender ? Gender.Male : Gender.Female,
                   // Gender = p.Gender.HasValue ? (p.Gender.Value ? Gender.Male : Gender.Female) : (Gender?)null


                })
                .ToList();

            var totalItems = AlldAta.Count(c => c.IsDeleted == false);
            var totalPages = (int)Math.Ceiling((double)totalItems / items);

            var resultDataList = new ResultDataList<GetAllPatients>()
            {
                Entities = patients,
                Count = totalItems,
                TotalPages = totalPages,
                CurrentPage = pagenumber,
                PageSize = items

            };


            return resultDataList;
        }

        public async Task<GetAllPatients> GetOne(string ID)
        {
            var onePatient = await _patientReposatory.GetByIdAsync(ID);
            var Patient = _mapper.Map<GetAllPatients>(onePatient);
            return Patient;
        }

        public async Task<int> SaveShanges()
        {
            return await _patientReposatory.SaveChangesAsync();
        }

        public async Task<ResultView<GetAllPatients>> SoftDelete(GetAllPatients patient)
        {
            try
            {
                var patientm = _mapper.Map<Patient>(patient);
                var Oldpatient = (await _patientReposatory.GetAllAsync()).FirstOrDefault(p => p.Id == patient.Id);
                Oldpatient.IsDeleted = true;
                await _patientReposatory.SaveChangesAsync();
                var patientDto = _mapper.Map<GetAllPatients>(Oldpatient);
                return new ResultView<GetAllPatients> { Entity = patientDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<GetAllPatients> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }

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
}
