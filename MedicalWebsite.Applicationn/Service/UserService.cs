using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private IMapper _mapper;
        public UserService( IUserRepository userRepository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
           _emailSender= emailSender;
            _userManager = userManager;
            _mapper = mapper;
        }
        public Task<ResultView<BlockUserDTO>> BlockUser(BlockUserDTO blockUserDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<List<UserDTO>>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<List<UserDTO>>> GetAllUsersPages(int items, int pagenumber)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<UserDTO>> LoginAsync(UserLoginDTO userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutUser()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultView<RegisterDTO>> Registration(RegisterDTO account, string? RoleName)
        {

             
            try { 
            var exitingUser= await _userManager.FindByEmailAsync(account.Email);
            if (exitingUser ==null)
            {
                    // var NewUser = _mapper.Map<User>(account);

                    var NewUser = new Doctor
                    {
                        Email = account.Email,
                        UserName=account.UserName,
                        PhoneNumber=account.Phone,
                        Adress=account.Adress,
                        Gender=account.Gender,
                        Education=account.Education,
                        SpecializationId= account.SpecializationId,
                       // EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(NewUser, account.password);
                    if (result.Succeeded) 
                    {
                        var token = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);
                        var confirmationLink = $"http://localhost:46580/api/Doctor/confirm-email?userId={NewUser.Id}&token={Uri.EscapeDataString(token)}";

                        // Send the email
                        await _emailSender.SendEmailAsync(NewUser.Email, "Confirm your email",
                            $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>");

                        await _userManager.AddToRoleAsync(NewUser, RoleName);

                        var registeredUserDto = _mapper.Map<RegisterDTO>(NewUser);
                        return new ResultView<RegisterDTO>()
                        {
                            Entity = registeredUserDto,
                            IsSuccess = true,
                            Message = "User registered successfully."
                        };
                    }
                    else
                    {
                        return new ResultView<RegisterDTO>()
                        {
                            Entity = null,
                            IsSuccess = false,
                            Message = $"Failed to register user. Error: {string.Join(", ", result.Errors)}"
                        };
                    }
            }
                return new ResultView<RegisterDTO>()
                {
                    Entity = account,
                    IsSuccess = false,
                    Message = "User already exists"
                };

            }
            catch (Exception e) 
            {
                return new ResultView<RegisterDTO>()
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = "An unexpected error occurred during registration."
                };
            }
        }


        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }
            return await _userManager.ConfirmEmailAsync(user, token);
        }
        public Task<ResultView<UserDTO>> SoftDeleteUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
