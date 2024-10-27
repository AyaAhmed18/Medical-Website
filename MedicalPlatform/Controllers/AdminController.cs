using MedicalWebsite.DTOS.User;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AdminController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("Login Admin")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.password))          
                return BadRequest("Email and password are required.");


           var user = await _userManager.FindByEmailAsync(loginDto.Email.Trim());

                    //user.EmailConfirmed = true;
                    //await _userManager.UpdateAsync(user);
                    //if (!await _userManager.IsEmailConfirmedAsync(user))
                    //{
                    //    return Unauthorized("Please confirm your email to log in.");
                    //}


            if (user == null)
            {
                return Unauthorized("User not found. Check email formatting.");
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (!isAdmin)
             return Unauthorized("Access denied. Only admins can log in.");

            


            var result = await _signInManager.PasswordSignInAsync(user, loginDto.password, loginDto.rememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
              return Unauthorized("Invalid password.");
            

            return Ok(new
            {
                Message = "Admin login successful",
                Email = user.Email,
                Password=user.PasswordHash,
                UserName=user.UserName,
                UserId = user.Id
            });
        }
    }

}
