using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Specialization;
using MedicalWebsite.DTOS.ViewResult;
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

        public async Task<ResultDataList<SpecializationDto>> GetAllSpecsAsync()
        {
            try
            {
                var Specs = await _SpicallizationRepository.GetAllAsync();

                var SpecsDTO = Specs.Where(c => c.IsDeleted == false).Select(c => new SpecializationDto
                {
                   Title = c.Title,
                   
                }).ToList();

                ResultDataList<SpecializationDto> result = new ResultDataList<SpecializationDto>();
                result.Entities = SpecsDTO;
                result.Count = SpecsDTO.Count();
                return result;
            }
            catch (Exception ex)
            {
                ResultDataList<SpecializationDto> result = new ResultDataList<SpecializationDto>();
                result.Entities = null;
                result.Count = 0;
                return result;
            }
        }
    }
}
