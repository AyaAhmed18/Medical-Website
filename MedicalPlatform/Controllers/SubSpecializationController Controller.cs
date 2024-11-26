using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Specialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Iservices;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSpecializationController : ControllerBase
    {
        private readonly ISubSpecializationService _subSpecializationService;
        private readonly ITreatmentService _treatmentService;

        public SubSpecializationController(ISubSpecializationService subSpecializationService, ITreatmentService treatmentService)
        {
            _subSpecializationService = subSpecializationService;
            _treatmentService = treatmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubSpecialization([FromBody] CreatorupdateSubSpecialization sub)
        {
            try
            {
                var result = await _subSpecializationService.CreateAsync(sub);
                return Ok(result.Entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int items, int pageNumber)
        {
            var result = await _subSpecializationService.GetAllAsync(items, pageNumber);
            if (result.Entities == null)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetTreatmentsBySubSpecializationId/{subspecializationId}")]
        public async Task<IActionResult> GetTreatmentsBySubSpecializationId(Guid subspecializationId)
        {
            try
            {
                var result = await _subSpecializationService.GetTreatmentsBySubSpecializationIdAsync(subspecializationId);
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

        //[HttpGet("GetByDiscountedTreatments")]
        //public async Task<IActionResult> GetByDiscountedTreatments( int items, int pageNumber)
        //{
        //    var result = await _subSpecializationService.GetSubSpecializationsWithDiscountedTreatmentsAsync(items, pageNumber);
        //    if (result.Entities == null)
        //        return BadRequest(result);

        //    return Ok(result);
        //}
    }
}

