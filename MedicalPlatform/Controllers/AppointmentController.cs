using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.Models.Models;
namespace MedicalPlatform.Controllers
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
        public async Task<IActionResult> UpdateAppointment(Guid id, CreatorUpdateAppointment appointment)
        {
            try
            {

                var result = await _appointmentService.Update(id,appointment);
                return Ok(result.Entity);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //testpush
        }
      


        [HttpGet]
        public async Task<IActionResult> GetAllAppointments(int pageSize, int pageNumber=1)
        {
            try
            {
                var appointment = await _appointmentService.GetAllPagination(pageSize, pageNumber);
                
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            try
            {
                var appointment = await _appointmentService.GetOne(id);
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
                //var app = await _appointmentService.GetOne(id);
                var result = await _appointmentService.SoftDelete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
