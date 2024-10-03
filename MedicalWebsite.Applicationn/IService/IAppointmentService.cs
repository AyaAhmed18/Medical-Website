using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Dtos.Appointment;
using Vezeeta.Dtos.ResultView;
using Vezeeta.Dtos.ViewResultDtos;

namespace Vezeeta.Application.Iservices
{
    public interface IAppointmentService
    {
        Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment Appointment);


        Task<ResultView<CreatorUpdateAppointment>> SoftDelete(CreatorUpdateAppointment Appointment);
        Task<ResultView<CreatorUpdateAppointment>> HardDelete(CreatorUpdateAppointment Appointment);

        Task<ResultDataForPagination<GetAllAppointement>> GetAllPagination(int items, int pagenumber);
        Task<CreatorUpdateAppointment> GetOne(int ID);

        Task<ResultView<CreatorUpdateAppointment>> Update(CreatorUpdateAppointment Appointment);


        Task<int> SaveShanges();
    }
}
