using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.User;
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
           // string decodedToken = WebUtility.UrlDecode(token);
            var result = await _doctorService.ConfirmEmailAsync(userId, token);

            if (result.Succeeded)
            {
                return Ok(new { message = "Email confirmed successfully!" });
            }

            return BadRequest(result.Errors);
        }
    }
}
