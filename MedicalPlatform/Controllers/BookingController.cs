using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _BookingService;

        public BookingController(IBookingService BookingService)
        {
            _BookingService = BookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Booking = (await _BookingService.GetAllBooking());
            if (Booking != null)
                return Ok(Booking.Entities);
            else
                return Ok(null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Booking = (await _BookingService.GetByIdAsync(id));
            if (Booking != null)
                return Ok(Booking);
            else
                return Ok(null);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrUpdateBooking BookDTO)
        {
            if (ModelState.IsValid)
            {
                var NewBook = await _BookingService.AddBooking(BookDTO);
                if (NewBook.IsSuccess)
                    return Ok(NewBook);
                else
                    return BadRequest(NewBook.Message);
            }
            else
                return BadRequest("InValid Data");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CreateOrUpdateBooking BookDTO)
        {

            if (ModelState.IsValid)
            {
                var UpdatedBook = await _BookingService.UpdateBooking(BookDTO);
                if (UpdatedBook.IsSuccess)
                    return Ok(UpdatedBook.Entity);
                else
                    return BadRequest(UpdatedBook.Message);

            }
            else
                return BadRequest("InValid Data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var booking = await _BookingService.GetByIdAsync(id);
            if (booking != null)
            {
                var deletedbooking = await _BookingService.HardDelete(id);
                if (deletedbooking.IsSuccess)
                    return Ok(booking);
                else return BadRequest(deletedbooking.Message);
            }
            return BadRequest("topic Not found");
        }
    }
}
