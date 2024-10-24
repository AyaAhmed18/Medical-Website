using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalWebsite.Applicationn.IService
{
    public interface IPatientService
    {
        ////Task<ResultView<CreatorUpdatePatient>> Create(CreatorUpdatePatient patient);
        ////Task<ResultView<CreatorUpdatePatient>> Update(CreatorUpdatePatient patient);
        //Task<ResultView<GetAllPatients>> SoftDelete(GetAllPatients patient);
        //Task<ResultDataList<GetAllPatients>> GetAllPagination(int items, int pagenumber);
        //Task<GetAllPatients> GetOne(string ID);
        //Task<int> SaveShanges();




        Task<ResultView<CreatorUpdatePatient>> RegisterAsPatient(CreatorUpdatePatient account);  

        Task<ResultView<CreatorUpdatePatient>> LoginAsPatient(string id);
        Task<ResultDataList<GetAllPatients>> GetAllPatientsPages(int items, int pagenumber);///
        Task<ResultView<CreatorUpdatePatient>> GetPatientById(string id);//
        Task<ResultView<CreatorUpdatePatient>> HardDeletePatient(string id);
        Task<ResultView<CreatorUpdatePatient>> BlockPatient(string PatientId);
        Task<ResultView<CreatorUpdatePatient>> UpdatePatient(GetAllPatients PatientDo);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
    }
}
