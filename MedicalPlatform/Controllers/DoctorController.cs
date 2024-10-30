using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
      //  private readonly IUserService _userService;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _doctorService=doctorService;
            _logger = logger;
        }
        [HttpGet("AllDoctorPages/{items}/{pageNumber}")]
       // [Authorize(Roles = "admin")]
        public async Task<IActionResult> AllDoctorPages(int items, int pageNumber = 1)
        {
            try
            {
                var users = await _doctorService.GetAllDoctorsPages(items, pageNumber);
                if (users.Count>0)
                {
                    return Ok(users);
                }
                else
                {
                    return Problem(statusCode: 400, title: "Failed to get paginated users");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting paginated users");
                return StatusCode(500, "An internal server error occurred");
            }
        }

        // GET api/<TopicController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var topic = (await _doctorService.GetDoctorById(id));
            if (topic != null)
                return Ok(topic);
            else
                return Ok(null);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreatorUpdateDoctor DoctorDTO)
        {

            if (ModelState.IsValid)
            {
                var UpdatedDoctor = await _doctorService.UpdateDoctor(DoctorDTO);
                if (UpdatedDoctor.IsSuccess)
                    return Ok(UpdatedDoctor.Entity);
                else
                    return BadRequest(UpdatedDoctor.Message);

            }
            else
                return BadRequest("InValid Data");
        }

      
        [HttpPut("ApproveDoctor/{id}")]
        public async Task<IActionResult> Delete(CreatorUpdateDoctor DoctorDto)
        {
            var doctor = await _doctorService.GetDoctorById(DoctorDto.Id);
            if (doctor != null)
            {
                var deleteddoctor = await _doctorService.HardDeleteDoctor(DoctorDto);
                if (deleteddoctor.IsSuccess)
                    return Ok(doctor);
                else return BadRequest(deleteddoctor.Message);
            }
            return BadRequest("topic Not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ApproveDoctor(CreatorUpdateDoctor DoctorDto)
        {
            var doctor = await _doctorService.GetDoctorById(DoctorDto.Id);
            if (doctor != null)
            {
                var deleteddoctor = await _doctorService.ApproveDoctor(DoctorDto.Id);
                if (deleteddoctor.IsSuccess)
                    return Ok(doctor);
                else return BadRequest(deleteddoctor.Message);
            }
            return BadRequest("doctor Not found");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _doctorService.RegisterAsDoctor(account);
                   
                    if (result.IsSuccess)
                    {
                        return Ok(new { message = "Registration successful. Please confirm your email." });

                    }
                    else
                    {
                        return Problem(statusCode: 400, title: "Registration Failed", detail: result.Message);
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration");
                return StatusCode(500, "An internal server error occurred");
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid email confirmation request.");
            }
          
            var result = await _doctorService.ConfirmEmailAsync(userId, token);

            if (result.Succeeded)
            {
                return Ok(new { message = "Email confirmed successfully!" });
            }

            return BadRequest(result.Errors);
        }
    }
}
