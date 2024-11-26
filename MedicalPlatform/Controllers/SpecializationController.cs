using MedicalWebsite.DTOS.Offers;
using MedicalWebsite.DTOS.Specialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Iservices;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpeciallizationService _speciallizationService;

        public SpecializationController(ISpeciallizationService speciallizationService)
        {
            _speciallizationService = speciallizationService;
        }
        // GET: api/<TopicController>

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] CreatorupdateSubSpecialization Specialization)
        {
            try
            {
                var result = await _speciallizationService.Create(Specialization);
                if (result.IsSuccess)
                {
                    return Ok(result.Entity);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get(int pageSize, int pageNumber = 1)
        {
            var Specs = (await _speciallizationService.GetAllSpecsAsync(pageSize, pageNumber));
            if (Specs != null)
                return Ok(Specs.Entities);
            else
                return Ok(null);
        }

        
        [HttpGet("GetSubSpecializationsBySpecializationId/{specializationId}")]
        public async Task<IActionResult> GetSubSpecializationsBySpecializationId(Guid specializationId)
        {
            try
            {
                var result = await _speciallizationService.GetSubSpecializationsBySpecializationId(specializationId);
                if (result.Entities != null && result.Count > 0)
                {
                    return Ok(result.Entities);
                }
                return NotFound("No sub-specializations found for the given specialization.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

