using MedicalWebsite.Applicationn.Service;
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
        private readonly EmailService _emailService;
        public AdminController(EmailService emailService ,SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AdminController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost("Login Admin")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.password))
                return BadRequest("Email and password are required.");


            var user = await _userManager.FindByEmailAsync(loginDto.Email.Trim());

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return Unauthorized("Please confirm your email to log in.");
            }


            if (user == null)
            {
                return Unauthorized("User not found. Check email formatting.");
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            if (!isAdmin)
                return Unauthorized("Access denied. Only admins can log in.");




             var result = await _signInManager.PasswordSignInAsync(user, loginDto.password, loginDto.rememberMe, lockoutOnFailure: false);
            //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var result = await _userManager.ResetPasswordAsync(user, token, user.PasswordHash);

            if (!result.Succeeded)
                return Unauthorized("Invalid password.");


            return Ok(new
            {
                Message = "Admin login successful",
                Email = user.Email,
                Password = user.PasswordHash,
                UserName = user.UserName,
                UserId = user.Id
            });
        }

        //[HttpPost("ForgotPassword")]
        //public async Task<IActionResult> ForgotPassword([FromBody] UserLoginDTO forgotPasswordDto)
        //{
        //    if (forgotPasswordDto == null || string.IsNullOrEmpty(forgotPasswordDto.Email))
        //        return BadRequest("Email is required.");

        //    var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email.Trim());
        //    if (user == null)
        //        return BadRequest("User not found.");

        //    // Generate the reset token
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var resetLink = Url.Action("ResetPassword", "Admin", new { userId = user.Id, token }, Request.Scheme);
          
        //    // Send the email (use your email sender service)
        //    await _emailService.SendEmailAsync(forgotPasswordDto.Email, "Reset Password",
        //        $"Please reset your password by clicking here: <a href='{resetLink}'>Reset Password</a>");

        //    return Ok("Password reset link has been sent to your email.");
        //}

    }


}


