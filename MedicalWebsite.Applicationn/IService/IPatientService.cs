using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalWebsite.Application.Iservices
{
    public interface IPatientService
    {
        //Task<ResultView<CreatorUpdatePatient>> Create(CreatorUpdatePatient patient);


        Task<ResultView<GetAllPatients>> SoftDelete(GetAllPatients patient);
        Task<ResultDataList<GetAllPatients>> GetAllPagination(int items, int pagenumber);
        Task<GetAllPatients> GetOne(string ID);

        //Task<ResultView<CreatorUpdatePatient>> Update(CreatorUpdatePatient patient);


        Task<int> SaveShanges();
    }
}
