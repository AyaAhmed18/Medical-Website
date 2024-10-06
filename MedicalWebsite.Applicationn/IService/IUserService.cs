using MedicalWebsite.DTOS.User;
using MedicalWebsite.DTOS.ViewResult;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.IService
{
    public interface IUserService
    {
        Task<ResultView<UserDTO>> LoginAsync(UserLoginDTO userDto);
        Task<ResultView<RegisterDTO>> Registration(RegisterDTO account, string? RoleName);
        Task<bool> LogoutUser();
        Task<ResultView<List<UserDTO>>> GetAllUsers();
        Task<ResultView<List<UserDTO>>> GetAllUsersPages(int items, int pagenumber);
        Task<ResultView<UserDTO>> SoftDeleteUser(string email);
        Task<ResultView<BlockUserDTO>> BlockUser(BlockUserDTO blockUserDTO);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
    }
}
