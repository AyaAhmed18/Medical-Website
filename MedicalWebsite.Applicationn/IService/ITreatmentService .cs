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
using MedicalWebsite.DTOS.Offers;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.DTOS.Treatment;
using Microsoft.AspNetCore.Http;

namespace MedicalWebsite.Applicationn.IService
{
    public interface ITreatmentService
    {
        
            Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment Treatment, IEnumerable<IFormFile> imageFiles);

        // Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment Treatment, IFormFile imageFile);

        //Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment Treatment);


        //Task<ResultDataList<GetAllTreatment>> GetTopPagination(int items, int pagenumber);

        Task<ResultDataList<GetAllTreatment>> GetAllPagination(int items, int pagenumber);
        
        Task<ResultView<GetAllTreatment>> GetTreatmentById(Guid id);

        Task<ResultDataList<GetAllTreatment>> GetTopTreatmentsInSubSpecialization();
        //Task<ResultView<CreateUpdateOffers>> Update(Guid id, CreateUpdateOffers offer);
        //Task<ResultView<GetAllOffers>> SoftDelete(GetAllOffers offer);
        //Task<ResultView<GetAllOffers>> HardDelete(GetAllOffers offer);
        //Task<ResultDataList<GetAllOffers>> GetOffersBySpecialization(Guid specializationId, int items, int pagenumber);
        //Task<ResultDataList<GetAllOffers>> GetSpecializationsWithOffers();
        //Task<GetAllOffers> GetOne(Guid offerId);
        Task<int> SaveChanges();

    }
}
