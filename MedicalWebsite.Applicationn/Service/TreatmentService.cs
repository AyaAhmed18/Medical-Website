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
using MedicalWebsite.DTOS.Treatment;
using System.Numerics;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices;
namespace MedicalWebsite.Applicationn.Service
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISubSpecializationRepository _subSpecializationRepository;
        private readonly IMapper _mapper;
        public TreatmentService(ITreatmentRepository treatmentRepository, IDoctorRepository doctorRepository, ISubSpecializationRepository subSpecializationRepository, IMapper mapper )
        {
            _treatmentRepository = treatmentRepository;
            _doctorRepository = doctorRepository;
            _subSpecializationRepository = subSpecializationRepository;
            _mapper = mapper;
        }
        //first ni image

        //public async Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment Treatment)
        //{
        //    try
        //    { 

        //        // i will do it last time that make sure that Doctor and subSpecialization belong to smae Specialization
        //        //    var doctor = await _doctorRepository.GetByIdAsync(Treatment.DoctorId);
        //        //    var subSpecialization = await _subSpecializationRepository.GetByIdAsync(Treatment.SubSpecializationId);
        //        // if (doctor.SpecializationId != subSpecialization.SpecializationId)
        //        //throw new Exception("Doctor and SubSpecialization must belong to the same Specialization.");


        //    var newTreatment = _mapper.Map<Treatment>(Treatment);

        //        if (newTreatment.Discount.HasValue )
        //        {
        //            newTreatment.NewPrice = newTreatment.Price -
        //                                  (newTreatment.Price * newTreatment.Discount.Value / 100);
        //        }
        //        else
        //        {
        //            newTreatment.NewPrice = newTreatment.Price;
        //        }

        //        await _treatmentRepository.CreateAsync(newTreatment);
        //        await _treatmentRepository.SaveChangesAsync();

        //        var result = _mapper.Map<CreateUpdateTreatment>(newTreatment);
        //        return new ResultView<CreateUpdateTreatment>
        //        {
        //            Entity = result,
        //            IsSuccess = true,
        //            Message = "offer created successfully."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreateUpdateTreatment>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"error creating offer: {ex.Message}"
        //        };
        //    }
        //}
        public async Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment treatment, IEnumerable<IFormFile> imageFiles)
        {
            try
            {
                var newTreatment = _mapper.Map<Treatment>(treatment);

                newTreatment.NewPrice = treatment.Discount.HasValue
                    ? newTreatment.Price - (newTreatment.Price * treatment.Discount.Value / 100)
                    : newTreatment.Price;

                List<string> imageUrls = new List<string>();

                if (imageFiles != null && imageFiles.Any())
                {
                    string uploadsFolder = Path.Combine("images", "treatments");
                    Directory.CreateDirectory(uploadsFolder); 

                    foreach (var imageFile in imageFiles)
                    {
                        if (imageFile.Length > 0)
                        {
                            string uniqueFileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await imageFile.CopyToAsync(fileStream);
                            }

                            imageUrls.Add($"/images/treatments/{uniqueFileName}".Replace("\\", "/"));
                        }
                    }
                }

                newTreatment.Image = string.Join(",", imageUrls);

                await _treatmentRepository.CreateAsync(newTreatment);
                await _treatmentRepository.SaveChangesAsync();

                var result = _mapper.Map<CreateUpdateTreatment>(newTreatment);
                return new ResultView<CreateUpdateTreatment>
                {
                    Entity = result,
                    IsSuccess = true,
                    Message = "Treatment created successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreateUpdateTreatment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Error creating treatment: {ex.Message}"
                };
            }
        }

        ////with img
        //public async Task<ResultView<CreateUpdateTreatment>> Create(CreateUpdateTreatment treatment, IFormFile imageFile)
        //{
        //    try
        //    {
        //        var newTreatment = _mapper.Map<Treatment>(treatment);

        //        newTreatment.NewPrice = treatment.Discount.HasValue
        //            ? newTreatment.Price - (newTreatment.Price * treatment.Discount.Value / 100)
        //            : newTreatment.Price;

        //        if (imageFile != null && imageFile.Length > 0)
        //        {
        //            string uploadsFolder = Path.Combine( "images", "treatments");
        //            Directory.CreateDirectory(uploadsFolder); 
        //            string uniqueFileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await imageFile.CopyToAsync(fileStream);
        //            }

        //            newTreatment.Image = $"/images/treatments/{uniqueFileName}".Replace("\\", "/");
        //        }

        //        await _treatmentRepository.CreateAsync(newTreatment);
        //        await _treatmentRepository.SaveChangesAsync();

        //        var result = _mapper.Map<CreateUpdateTreatment>(newTreatment);
        //        return new ResultView<CreateUpdateTreatment>
        //        {
        //            Entity = result,
        //            IsSuccess = true,
        //            Message = "Treatment created successfully."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreateUpdateTreatment>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"Error creating treatment: {ex.Message}"
        //        };
        //    }
        //}

        public async Task<ResultDataList<GetAllTreatment>> GetAllPagination(int items, int pagenumber)
        {
            try
            {

               

                var allData = (await _treatmentRepository.GetTreatmentsWithIncludesAsync())
                .Where(c => (bool)!c.IsDeleted)
                 .Include(o => o.SubSpecialization)
                 .Include(o => o.Doctor)
                 .ToList();



                var treatments = allData.Skip(items * (pagenumber - 1))
                    .Take(items)
                    .Select(p => new GetAllTreatment
                    {
                        Id = p.Id,
                        Name = p.Name,
                        DoctorId = p.DoctorId,
                        DoctorName = p.Doctor?.UserName,
                        Price = p.Price,
                        Image = p.Image,
                        Discount = p.Discount,
                        Description = p.Description,
                        NewPrice = p.Discount.HasValue && p.Discount.Value > 0
                            ? p.Price - (p.Price * p.Discount.Value / 100)
                            : p.Price,
                        SubSpecializationName = p.SubSpecialization?.Name,
                    })
                    .ToList();

                var totalItems = allData.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                return new ResultDataList<GetAllTreatment>
                {
                    Entities = treatments,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        //public async Task<ResultDataList<GetAllTreatment>> GetTopPagination(int items, int pagenumber)
        //{
        //    try
        //    {
        //        var allData = (await _treatmentRepository.GetAllAsync())
        //            .Where(c => (bool)!c.IsDeleted && c.Discount > 30)
        //            .Include(o => o.SubSpecialization)
        //            .Include(o => o.Doctor)
        //            .ToList();

        //        var treatments = allData.Skip(items * (pagenumber - 1))
        //            .Take(items)
        //            .Select(p => new GetAllTreatment
        //            {
        //                Id = p.Id,
        //                Name = p.Name,
        //                DoctorName = p.Doctor?.UserName,
        //                Price = p.Price,
        //                Discount = p.Discount,
        //                Description = p.Description,
        //                NewPrice = p.Discount.HasValue && p.Discount.Value > 0
        //                    ? p.Price - (p.Price * p.Discount.Value / 100)
        //                    : p.Price,
        //                SubSpecializationName = p.SubSpecialization?.Name,
        //            })
        //            .ToList();

        //        var totalItems = allData.Count;
        //        var totalPages = (int)Math.Ceiling((double)totalItems / items);

        //        return new ResultDataList<GetAllTreatment>
        //        {
        //            Entities = treatments,
        //            Count = totalItems,
        //            TotalPages = totalPages,
        //            CurrentPage = pagenumber,
        //            PageSize = items
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}

        public async Task<ResultView<GetAllTreatment>> GetTreatmentById(Guid id)
        {
            try
            {
              
                var treatment = (await _treatmentRepository.GetAllAsync())
                    .Where(t => t.Id == id && (bool)!t.IsDeleted)
                    .Include(t => t.SubSpecialization)
                    .Include(t => t.Doctor)
                    .FirstOrDefault();

                    var treatmentDto = new GetAllTreatment
                    {
                        Id = treatment.Id,
                        Name = treatment.Name,
                        DoctorId = treatment.DoctorId,
                        DoctorName = treatment.Doctor?.UserName,
                        Price = treatment.Price,
                        Image = treatment.Image,
                        Discount = treatment.Discount,
                        Description = treatment.Description,
                        NewPrice = treatment.Discount.HasValue && treatment.Discount.Value > 0
                            ? treatment.Price - (treatment.Price * treatment.Discount.Value / 100)
                            : treatment.Price,
                        SubSpecializationName = treatment.SubSpecialization?.Name,
                    };

                    return new ResultView<GetAllTreatment>
                    {
                        Entity = treatmentDto,
                        IsSuccess = true,
                        Message = "Treatment retrieved successfully."
                    };
            }
            catch (Exception ex)
            {
                return new ResultView<GetAllTreatment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Error retrieving treatment: {ex.Message}"
                };
            }
        }

       
        public async Task<ResultDataList<GetAllTreatment>> GetTopTreatmentsInSubSpecialization()
        {
            try
            {
                var allTreatments = await _treatmentRepository.GetAllAsync();
                var topTreatments = allTreatments
                    .Where(t => (bool)!t.IsDeleted && t.Discount.HasValue && t.Discount > 0)
                     .Include(o => o.SubSpecialization)
                     .Include(o => o.Doctor)
                    .GroupBy(t => t.SubSpecializationId)
                    .Select(g => g.OrderByDescending(t => t.Discount).First())
                    .ToList();

                var treatmentDtos = topTreatments
                   .Select(t => new GetAllTreatment
                        {
                            Id = t.Id,
                            Name = t.Name,
                            DoctorId = t.DoctorId,
                            DoctorName = t.Doctor?.UserName,
                            Price = t.Price,
                            Image=t.Image,
                            Discount = t.Discount,
                            Description = t.Description,
                            NewPrice = t.Discount.HasValue && t.Discount.Value > 0
                                ? t.Price - (t.Price * t.Discount.Value / 100)
                                : t.Price,
                            SubSpecializationName = t.SubSpecialization?.Name,
                        }).ToList();

                return new ResultDataList<GetAllTreatment>
                {
                    Entities = treatmentDtos,
                    Count = treatmentDtos.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResultDataList<GetAllTreatment>
                {
                    Entities = null,
                };
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _treatmentRepository.SaveChangesAsync();
        }


        //public Task<ResultView<GetAllOffers>> SoftDelete(GetAllOffers offer)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<ResultView<CreateUpdateOffers>> Update(Guid id, CreateUpdateOffers offer)
        //{
        //    try
        //    {
        //        var existingoffer = await _treatmentRepository.GetByIdAsync(id);
        //        _mapper.Map(offer, existingoffer);

        //        var updatedoffer = await _treatmentRepository.UpdateAsync(existingoffer);
        //        await _treatmentRepository.SaveChangesAsync();

        //        var updatedofferDto = _mapper.Map<CreateUpdateOffers>(updatedoffer);

        //        return new ResultView<CreateUpdateOffers>
        //        {
        //            Entity = updatedofferDto,
        //            IsSuccess = true,
        //            Message = "Appointment updated successfully."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreateUpdateOffers>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"Something went wrong: {ex.Message}"
        //        };
        //    }
        //}




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
