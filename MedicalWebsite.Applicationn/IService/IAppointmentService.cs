using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalWebsite.Application.Iservices
{
    public interface IAppointmentService
    {
        Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment Appointment);


        Task<ResultView<CreatorUpdateAppointment>> SoftDelete(CreatorUpdateAppointment Appointment);
        Task<ResultView<CreatorUpdateAppointment>> HardDelete(CreatorUpdateAppointment Appointment);

        Task<ResultDataList<GetAllAppointement>> GetAllPagination(int items, int pagenumber);
        Task<CreatorUpdateAppointment> GetOne(Guid ID);

        Task<ResultView<CreatorUpdateAppointment>> Update(CreatorUpdateAppointment Appointment);


        Task<int> SaveShanges();
    }
}
