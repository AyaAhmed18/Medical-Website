using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Booking;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Service
{
    public class BookingService:IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public  BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task<ResultView<CreateOrUpdateBooking>> AddBooking(CreateOrUpdateBooking BookingDTO)
        {
            ResultView<CreateOrUpdateBooking> result = new();
            try
            {
                //var topics = await _bookingRepository.GetAllAsync();
                //var oldTopic = topics.Where(i => i.Name == topic.Name).FirstOrDefault();

                //if (oldTopic != null)
                //{
                //    result.IsSuccess = false;
                //    result.Entity = null;
                //    result.Message = "This Booking Data is already Exist";
                //    return result;
                //}
                var BookData = _mapper.Map<Booking>(BookingDTO);
                var NewBookData = await _bookingRepository.CreateAsync(BookData);
                await _bookingRepository.SaveChangesAsync();
                var NewBookDataDto = _mapper.Map<CreateOrUpdateBooking>(NewBookData);
                result.Entity = NewBookDataDto;
                result.IsSuccess = true;
                result.Message = "Booking Data Added Successfully";
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Entity = null;
                result.Message = "Something went wrong";
                return result;

            }
        }

        public async Task<ResultDataList<GetAllBooking>> GetAllBooking()
        {
            try
            {
                var Topics = await _bookingRepository.GetAllAsync();

                var TopicDTO = Topics.Where(c => c.IsDeleted == false).Include(i => i.Doctor).Select(c=>new GetAllBooking()
                {
                    Doctor=c.Doctor.UserName,
                    fees=c.fees,
                    StartDay=c.StartDay,
                    EndDay=c.EndDay,
                    StartHour=c.StartHour,
                    EndHour=c.EndHour,
                    watingTime=c.watingTime

                }).ToList(); 

                ResultDataList<GetAllBooking> result = new ResultDataList<GetAllBooking>();
                result.Entities = TopicDTO;
                result.Count = TopicDTO.Count();
                return result;
            }
            catch (Exception ex)
            {
                ResultDataList<GetAllBooking> result = new ResultDataList<GetAllBooking>();
                result.Entities = null;
                result.Count = 0;
                return result;
            }
        }

        public Task<ResultDataList<GetAllBooking>> GetAllBookingPagenated(int iteams, int Count)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<CreateOrUpdateBooking>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<CreateOrUpdateBooking>> HardDelete(Guid BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<CreateOrUpdateBooking>> SoftDelete(Guid BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<ResultView<CreateOrUpdateBooking>> UpdateBooking(CreateOrUpdateBooking BookingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
