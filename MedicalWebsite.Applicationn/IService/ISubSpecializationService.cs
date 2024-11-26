using MedicalWebsite.DTOS.Specialization;
using MedicalWebsite.DTOS.Treatment;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.IService
{
    public interface ISubSpecializationService
    {
        Task<ResultView<CreatorupdateSubSpecialization>> CreateAsync(CreatorupdateSubSpecialization subSpecializationDto);
        Task<ResultDataList<GetAllSubSpecializationDto>> GetAllAsync(int items, int pageNumber);
       // Task<ResultDataList<GetAllSubSpecializationDto>> GetSubSpecializationsWithDiscountedTreatmentsAsync(int items, int pageNumber);

        Task<ResultDataList<GetAllTreatment>> GetTreatmentsBySubSpecializationIdAsync(Guid subspecializationId);
     

    }
}
