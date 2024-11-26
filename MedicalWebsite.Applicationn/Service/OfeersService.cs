using MedicalWebsite.DTOS.ViewResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Offers;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MedicalWebsite.DTOS.Appointment;
namespace MedicalWebsite.Applicationn.Service
{
    public class OfeersService:IOffersService
    {
        private readonly IOffersRepository _offerRepository;
        private readonly IMapper _mapper;
        public OfeersService(IOffersRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
         
        }

        public async Task<ResultView<CreateUpdateOffers>> CreateOffer(CreateUpdateOffers offer)
        {
            try
            {
                var newOffer = _mapper.Map<Offers>(offer);
                await _offerRepository.CreateAsync(newOffer);
                await _offerRepository.SaveChangesAsync();

                var result = _mapper.Map<CreateUpdateOffers>(newOffer);
                return new ResultView<CreateUpdateOffers>
                {
                    Entity = result,
                    IsSuccess = true,
                    Message = "offer created successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreateUpdateOffers>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"error creating offer: {ex.Message}"
                };
            }
        }
        public async Task<ResultDataList<GetAllOffers>> GetAllPagination(int items, int pagenumber)
        {
            try
            {
                var allData = (await _offerRepository.GetAllAsync())
                 .Where(c => (bool)!c.IsDeleted)
                 .Include(o => o.Specialization)
                 .ToList();


                var offers = allData.Skip(items * (pagenumber - 1))
                                          .Take(items)
                                          .Select(p => new GetAllOffers
                                          {
                                              Id = p.Id,
                                              Name = p.Name,
                                              DoctorName = p.Doctor?.UserName ?? "unknown doctor",
                                              Discount = p.Discount,
                                              SpecializationName = p.Specialization.Title,


                                          })
                                          .ToList();

                var totalItems = allData.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllOffers>
                {
                    Entities = offers,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items
                };

                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        public async Task<ResultDataList<GetAllOffers>> GetTopPagination(int items, int pagenumber)
        {
            try
            {
                var allData = (await _offerRepository.GetAllAsync())
                 .Where(c => (bool)!c.IsDeleted && c.Discount > 30)
                 .Include(o => o.Specialization)
                 .ToList();


                var offers = allData.Skip(items * (pagenumber - 1))
                                          .Take(items)
                                          .Select(p => new GetAllOffers
                                          {
                                              Id = p.Id,
                                              Name = p.Name,
                                              DoctorName = p.Doctor?.UserName ?? "unknown doctor",
                                              Discount = p.Discount,
                                              SpecializationName = p.Specialization.Title,


                                          })
                                          .ToList();

                var totalItems = allData.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllOffers>
                {
                    Entities = offers,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items
                };

                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public Task<ResultDataList<GetAllOffers>> GetOffersBySpecialization(Guid specializationId, int items, int pagenumber)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllOffers> GetOne(Guid offerId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultDataList<GetAllOffers>> GetSpecializationsWithOffers()
        {
            throw new NotImplementedException();
        }

       
        public Task<ResultView<GetAllOffers>> HardDelete(GetAllOffers offer)
        {
            throw new NotImplementedException();
        }

       

        public async Task<int> SaveChanges()
        {
            return await _offerRepository.SaveChangesAsync();
        }
        public Task<ResultView<GetAllOffers>> SoftDelete(GetAllOffers offer)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultView<CreateUpdateOffers>> Update(Guid id, CreateUpdateOffers offer)
        {
            try
            {
                var existingoffer = await _offerRepository.GetByIdAsync(id);
                _mapper.Map(offer, existingoffer);

                var updatedoffer = await _offerRepository.UpdateAsync(existingoffer);
                await _offerRepository.SaveChangesAsync();

                var updatedofferDto = _mapper.Map<CreateUpdateOffers>(updatedoffer);

                return new ResultView<CreateUpdateOffers>
                {
                    Entity = updatedofferDto,
                    IsSuccess = true,
                    Message = "Appointment updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreateUpdateOffers>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }




        //public async Task<ResultDataList<OffersSpecializationDTO>> GetSpecializationsWithOffers()
        //{
        //    var specializationsWithOffers = await _dbContext.Specializations
        //        .Where(s => s.Offer != null) // Filter specializations with offers
        //        .Select(s => new OffersSpecializationDTO
        //        {
        //            SpecializationId = s.Id,
        //            SpecializationTitle = s.Title,
        //            OfferName = s.Offer.Name,
        //            OfferDiscount = s.Offer.Discount,
        //            TreatmentCount = s.Treatment.Count() // Count treatments for each specialization
        //        })
        //        .ToListAsync();

        //    return new ResultDataList<OffersSpecializationDTO>
        //    {
        //        Success = true,
        //        Data = specializationsWithOffers
        //    };
        //}

    }
}
