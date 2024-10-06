using MedicalWebsite.DTOS.Booking;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.IService
{
    public interface IBookingService
    {
        Task<ResultView<CreateOrUpdateBooking>> AddBooking(CreateOrUpdateBooking BookingDTO);
        Task<ResultView<CreateOrUpdateBooking>> UpdateBooking(CreateOrUpdateBooking BookingDTO);
        Task<ResultView<CreateOrUpdateBooking>> HardDelete(Guid BookingId);
        Task<ResultView<CreateOrUpdateBooking>> SoftDelete(Guid BookingId);
        Task<ResultDataList<GetAllBooking>> GetAllBooking();
        Task<ResultDataList<GetAllBooking>> GetAllBookingPagenated(int iteams, int Count);
        Task<ResultView<CreateOrUpdateBooking>> GetByIdAsync(Guid id);
    }
}
