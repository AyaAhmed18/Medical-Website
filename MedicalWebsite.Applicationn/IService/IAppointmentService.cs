using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalWebsite.Applicationn.IService
{
    public interface IAppointmentService
    {
        Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment Appointment);


        Task<ResultView<CreatorUpdateAppointment>> SoftDelete(Guid id);
        Task<ResultView<CreatorUpdateAppointment>> HardDelete(Guid id);

        Task<ResultDataList<GetAllAppointement>> GetAllPagination(int items, int pagenumber);
        Task<CreatorUpdateAppointment> GetOne(Guid ID);

        Task<ResultView<CreatorUpdateAppointment>> Update(Guid id,CreatorUpdateAppointment Appointment);


        Task<int> SaveShanges();
    }
}
