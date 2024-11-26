using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Specialization;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Application.Iservices
{
    public interface ISpeciallizationService
    {
        Task<ResultView<CreatorupdateSubSpecialization>> Create(CreatorupdateSubSpecialization Specialization);

        Task<ResultDataList<GetAllSpecializationDto>> GetAllSpecsAsync(int items, int pagenumber);
       
        Task<ResultDataList<GetAllSpecializationDto>> GetSubSpecializationsBySpecializationId(Guid specializationId);
    }
}
