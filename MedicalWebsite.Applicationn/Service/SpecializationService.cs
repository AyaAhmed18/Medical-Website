using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Specialization;
using MedicalWebsite.DTOS.Treatment;
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
    public class SpecializationService:ISpeciallizationService
    {
        private readonly ISpicallizationRepository _SpicallizationRepository;
        private readonly IMapper _mapper;
        public SpecializationService(ISpicallizationRepository SpicallizationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _SpicallizationRepository = SpicallizationRepository;
        }

        public async Task<ResultView<CreatorupdateSubSpecialization>> Create(CreatorupdateSubSpecialization Specialization)
        {
            try
            {
                var newSpecialization = _mapper.Map<Specialization>(Specialization);
                var createdSpecialization = await _SpicallizationRepository.CreateAsync(newSpecialization);
                await _SpicallizationRepository.SaveChangesAsync();
                var createdSpecializationDto = _mapper.Map<CreatorupdateSubSpecialization>(createdSpecialization);

                return new ResultView<CreatorupdateSubSpecialization>
                {
                    Entity = createdSpecializationDto,
                    IsSuccess = true,
                    Message = "Appointment created successfully."
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


        public async Task<ResultDataList<GetAllSpecializationDto>> GetAllSpecsAsync(int items, int pagenumber)
        {
            try
            {
               
                var Specs = (await _SpicallizationRepository.GetAllAsync())
                     .Where(s => (bool)!s.IsDeleted)
                            .ToList(); ;

                var SpecsDTO = Specs.Skip(items * (pagenumber - 1))
                                          .Take(items)
                                          .Select(s => new GetAllSpecializationDto
                                          {
                                                Id = s.Id,
                                               Title = s.Title,
                   
                                            }).ToList();

                ResultDataList<GetAllSpecializationDto> result = new ResultDataList<GetAllSpecializationDto>();
                result.Entities = SpecsDTO;
                result.Count = SpecsDTO.Count();
                return result;
            }
            catch (Exception ex)
            {
                ResultDataList<GetAllSpecializationDto> result = new ResultDataList<GetAllSpecializationDto>();
                result.Entities = null;
                result.Count = 0;
                return result;
            }
        }

        public async Task<ResultDataList<GetAllSpecializationDto>> GetSubSpecializationsBySpecializationId(Guid specializationId)
        {
            try
            {
                var specialization = await _SpicallizationRepository.GetAllAsync();
                var subSpecializations = specialization
                    .Where(s => s.Id == specializationId && (bool)!s.IsDeleted)
                    .SelectMany(s => s.SubSpecializations)
                    .ToList();

                var subSpecializationsDto = subSpecializations.Select(s => new GetAllSpecializationDto
                {
                    Id = s.Id,
                    Title = s.Name 
                }).ToList();

                return new ResultDataList<GetAllSpecializationDto>
                {
                    Entities = subSpecializationsDto,
                    Count = subSpecializationsDto.Count
                };
            }
            catch (Exception ex)
            {
                return new ResultDataList<GetAllSpecializationDto>
                {
                    Entities = null,
                    Count = 0
                };
            }
        }

       
    }

}

