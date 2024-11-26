using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Specialization;
using MedicalWebsite.DTOS.Treatment;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Service
{
    public class SubSpecializationService : ISubSpecializationService
    {
        private readonly ISubSpecializationRepository _subSpecializationRepository;
        private readonly IMapper _mapper;

        public SubSpecializationService(ISubSpecializationRepository subSpecializationRepository, IMapper mapper)
        {
            _subSpecializationRepository = subSpecializationRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<CreatorupdateSubSpecialization>> CreateAsync(CreatorupdateSubSpecialization subSpecializationDto)
        {
            try
            {
                var subSpecialization = _mapper.Map<SubSpecialization>(subSpecializationDto);
                var createdEntity = await _subSpecializationRepository.CreateAsync(subSpecialization);
                await _subSpecializationRepository.SaveChangesAsync();

                var createdDto = _mapper.Map<CreatorupdateSubSpecialization>(createdEntity);

                return new ResultView<CreatorupdateSubSpecialization>
                {
                    Entity = createdDto,
                    IsSuccess = true,
                    Message = "subSpecialization created successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorupdateSubSpecialization>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }

        public async Task<ResultDataList<GetAllSubSpecializationDto>> GetAllAsync(int items, int pageNumber)
        {
            try
            {
                var subSpecializations = (await _subSpecializationRepository.GetAllAsync())
                    .Where(s => !(bool)s.IsDeleted)
                    .Include(s => s.Specialization) 
                    .Include(s => s.Treatments)
                     .Include(s => s.Specialization.Doctors)
                    .ToList();

                var pagedData = subSpecializations
                    .Skip(items * (pageNumber - 1))
                    .Take(items)
                    .Select(s => new GetAllSubSpecializationDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        SpecializationId = s.SpecializationId,
                        SpecializationName = s.Specialization.Title,
                        Treatments = s.Treatments
                            .Select(t => new GetAllTreatment
                            {
                                Id = t.Id,
                                DoctorId = t.DoctorId,
                                Name = t.Name,
                                Description = t.Description,
                                Price=t.Price,
                                Discount=t.Discount,
                                NewPrice=t.NewPrice,
                                Image=t.Image,
                              //  DoctorName=t.Doctor.UserName,
                               // DoctorName=t.SubSpecialization.Specialization.Doctors.username
                                SubSpecializationName =t.SubSpecialization.Name

                            }).ToList()
                    })
                    .ToList();

                return new ResultDataList<GetAllSubSpecializationDto>
                {
                    Entities = pagedData,
                    Count = subSpecializations.Count
                };
            }
            catch (Exception ex)
            {
                return new ResultDataList<GetAllSubSpecializationDto>
                {
                    Entities = null,
                    Count = 0,
                };
            }
        }

        //public async Task<ResultDataList<GetAllSubSpecializationDto>> GetSubSpecializationsWithDiscountedTreatmentsAsync(int items, int pageNumber)
        //{
        //    try
        //    {
        //        var subSpecializations = (await _subSpecializationRepository.GetAllAsync())
        //            .Where(s => s.Treatments.Any(t => t.Discount > 0))
        //            .ToList();

        //        var pagedData = subSpecializations
        //            .Skip(items * (pageNumber - 1))
        //            .Take(items)
        //            .Select(s => new GetAllSubSpecializationDto
        //            {
        //                Id = s.Id,
        //                Name = s.Name,
        //                Treatments = s.Treatments
        //                    .Where(t => t.Discount > 0)
        //                    .Select(t => new GetAllTreatment
        //                    {
        //                        Id = t.Id,
        //                        DoctorId = t.DoctorId,
        //                        Name = t.Name,
        //                        Description = t.Description,
        //                        Price = t.Price,
        //                        Discount = t.Discount,
        //                        NewPrice = t.NewPrice,
        //                        //  DoctorName=t.Doctor.UserName,
        //                        // DoctorName=t.SubSpecialization.Specialization.Doctors.username
        //                        SubSpecializationName = t.SubSpecialization.Name,
        //                    }).ToList()
        //            })
        //            .ToList();

        //        return new ResultDataList<GetAllSubSpecializationDto>
        //        {
        //            Entities = pagedData,
        //            Count = subSpecializations.Count
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultDataList<GetAllSubSpecializationDto>
        //        {
        //            Entities = null,
        //            Count = 0,
        //        };
        //    }
        //}

        public async Task<ResultDataList<GetAllTreatment>> GetTreatmentsBySubSpecializationIdAsync(Guid subSpecializationId)
        {
            try
            {
                var subSpecializations = await _subSpecializationRepository.GetAllAsync();

                var selectedSubSpecialization = subSpecializations
                    .Where(s => s.Id == subSpecializationId && !(bool)s.IsDeleted)
                    .Include(s => s.Treatments)
                    .FirstOrDefault();


                var treatments = selectedSubSpecialization.Treatments.Select(t => new GetAllTreatment
                {
                    Id = t.Id,
                    DoctorId = t.DoctorId,
                    Name = t.Name,
                    Description = t.Description,
                    Price = t.Price,
                    Image = t.Image,
                    Discount = t.Discount,
                    NewPrice = t.NewPrice,
                    SubSpecializationName = t.SubSpecialization?.Name
                }).ToList();

                return new ResultDataList<GetAllTreatment>
                {
                    Entities = treatments,
                    Count = treatments.Count,
                };
            }
            catch (Exception ex)
            {
                return new ResultDataList<GetAllTreatment>
                {
                    Entities = null,
                    Count = 0,
                };
            }
        }

     

    }
}
