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

namespace MedicalWebsite.Applicationn.IService
{
    public interface IOffersService
    {
        //Task<ResultView<CreateUpdateOffers>> CreateOffer(CreateUpdateOffers offer);
        //Task<ResultView<CreateUpdateOffers>> Update(Guid id, CreateUpdateOffers offer);

        //Task<ResultDataList<GetAllOffers>> GetTopPagination(int items, int pagenumber);

        Task<ResultView<CreateUpdateOffers>> CreateOffer(CreateUpdateOffers offer);
        Task<ResultView<CreateUpdateOffers>> Update(Guid id, CreateUpdateOffers offer);

        Task<ResultDataList<GetAllOffers>> GetTopPagination(int items, int pagenumber);

        Task<ResultView<GetAllOffers>> SoftDelete(GetAllOffers offer);
        Task<ResultView<GetAllOffers>> HardDelete(GetAllOffers offer);
        Task<ResultDataList<GetAllOffers>> GetAllPagination(int items, int pagenumber);
        Task<ResultDataList<GetAllOffers>> GetOffersBySpecialization(Guid specializationId, int items, int pagenumber);
        Task<ResultDataList<GetAllOffers>> GetSpecializationsWithOffers();
        Task<GetAllOffers> GetOne(Guid offerId);
        Task<int> SaveChanges();
       
    }
}
