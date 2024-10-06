using MedicalWebsite.DTOS.Doctor;
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
    public interface IDoctorService
    {
        Task<ResultView<RegisterDTO>> RegisterAsDoctor(RegisterDTO DoctorDto);
        Task<CreatorUpdateDoctor> LoginAsDoctor(CreatorUpdateDoctor DoctorDto);
        Task<ResultDataList<GetAllDoctors>> GetAllDoctors();
        Task<ResultDataList<GetAllDoctors>> GetDoctorsBySpecialization();
        Task<ResultDataList<GetAllDoctors>> GetDoctorsBy();
        Task<ResultView<CreatorUpdateDoctor>> GetDoctorById(string id);
        Task<ResultView<CreatorUpdateDoctor>> HardDeleteDoctor(CreatorUpdateDoctor DoctorDto);
        Task<ResultView<CreatorUpdateDoctor>> BlockDoctor(string DoctorId);
        Task<ResultView<CreatorUpdateDoctor>> UpdateDoctor(CreatorUpdateDoctor DoctorDto);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string token);
    }
}
