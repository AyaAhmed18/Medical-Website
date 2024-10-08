using MedicalWebsite.Application.Iservices;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlatform.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController( IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GettAllPatients")]
        public async Task<IActionResult> GettAllPatients(int pageNumber = 1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pageSize = 2;
            var productsDataList = await _patientService.GetAllPagination(pageSize, pageNumber);
            return Ok(productsDataList);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(GetAllPatients patient)
        {
            try
            {
                var gpatient = await _patientService.GetOne(patient.Id);
                return Ok(gpatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletPatient(string id)
        {
            try
            {
                var patient = await _patientService.GetOne(id);
                var result = await _patientService.SoftDelete(patient);
                return Ok("Patient Deleted  successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpPost("Create")]
        //public async Task<IActionResult> Create([FromBody] CreatorUpdatePatient patient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _patientService.Create(patient);

        //    if (!result.IsSuccess)
        //    {
        //        return BadRequest(result.Message);
        //    }

        //    return Ok(result.Entity);
        //}
    }

}
