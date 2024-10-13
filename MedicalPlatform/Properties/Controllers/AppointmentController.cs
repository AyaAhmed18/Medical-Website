using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalWebsite.Application.Iservices;
using MedicalWebsite.DTOS;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.Applicationn.Service;
namespace MedicalPlatform.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreatorUpdateAppointment appointment)
        {
            try
            {             
                var result = await _appointmentService.Create(appointment);
                return Ok(result.Entity);               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] CreatorUpdateAppointment appointment)
        {
            try
            {

                var result = await _appointmentService.Update(appointment);
                return Ok(result.Entity);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments(int pageSize, int pageNumber)
        {
            try
            {
                var appointment = await _appointmentService.GetAllPagination(pageSize, pageNumber);
                return Ok(appointment.Entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(CreatorUpdateAppointment Appointment)
        {
            try
            {
                var appointment = await _appointmentService.GetOne(Appointment.Id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletAppointment(Guid id)
        {
            try
            {
                var patient = await _appointmentService.GetOne(id);
                var result = await _appointmentService.SoftDelete(patient);
                return Ok("Appointment Deleted  successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
