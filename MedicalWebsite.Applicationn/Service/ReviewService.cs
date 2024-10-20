using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalWebsite.Applicationn.IService;
using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Patients;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Models.Models;
using Vezeeta.Application.Iservices;
using MedicalWebsite.DTOS.Review;
using MedicalWebsite.DTOS.Appointment;
namespace MedicalWebsite.Applicationn.Service
{
    public class ReviewService : IReviewService

    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }


        public async Task<ResultView<CreateUpdateReviews>> Create(CreateUpdateReviews review)
        {
            try
            {
                var rev = _mapper.Map<Review>(review);
                var Newrev = await _reviewRepository.CreateAsync(rev);
                await _reviewRepository.SaveChangesAsync();
                var ODto = _mapper.Map<CreateUpdateReviews>(Newrev);
                return new ResultView<CreateUpdateReviews>
                {
                    Entity = ODto,
                    IsSuccess = true,
                    Message = "Review Created Successfully"
                };


            }
            catch (Exception ex)
            {
                return new ResultView<CreateUpdateReviews>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }

        public async Task<ResultDataList<GetAllReviewsDto>> GetAllPagination(int items, int pagenumber)
        {
            try
            {
                var AlldAta = (await _reviewRepository.GetAllAsync())
                     .Where(r => (bool)!r.IsDeleted)
                     .ToList(); 

                var reviews = AlldAta.Skip(items * (pagenumber - 1)).Take(items)
                            .Select(p => new GetAllReviewsDto()
                            {
                                Id = p.Id,
                                Comment = p.Comment,
                                Rateing = p.Rating,
                                DoctorName = p.Doctor?.UserName ?? "Unknown Doctor",  
                                PatientName = p.Patient?.UserName ?? "Unknown Patient" 
                            })
                            .ToList();


                var totalItems = AlldAta.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllReviewsDto>
                {
                    Entities = reviews,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items,

                };
                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<ResultDataList<GetAllReviewsDto>> GetHighRate(int items, int pagenumber)
        {
            try
            {
                var AlldAta = (await _reviewRepository.GetAllAsync()).Where(r => r.Rating >= 4)
                     .Where(r => (bool)!r.IsDeleted)
                     .ToList();

                var review = AlldAta.Skip(items * (pagenumber - 1)).Take(items)
                           .Select(p => new GetAllReviewsDto()
                           {
                               Id = p.Id,
                               Comment = p.Comment,
                               Rateing = p.Rating,
                               DoctorName = p.Doctor?.UserName ?? "Unknown Doctor",
                               PatientName = p.Patient?.UserName ?? "Unknown Patient"
                           })
                           .ToList();

                var totalItems = AlldAta.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllReviewsDto>
                {
                    Entities = review,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items,

                };
                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


       

        public async Task<ResultView<GetAllReviewsDto>> SoftDelete(GetAllReviewsDto review)
        {

            try
            {
                var reviewm = _mapper.Map<Review>(review);
                var Oldreview = (await _reviewRepository.GetAllAsync()).FirstOrDefault(r => r.Id == review.Id);
                Oldreview.IsDeleted = true;
                await _reviewRepository.SaveChangesAsync();
                var reviewDto = _mapper.Map<GetAllReviewsDto>(Oldreview);
                return new ResultView<GetAllReviewsDto> { Entity = reviewDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<GetAllReviewsDto> { Entity = null, IsSuccess = false, Message = ex.Message };
            }
        }
        public Task<ResultView<CreateUpdateReviews>> HardDelete(CreateUpdateReviews review)
        {
            throw new NotImplementedException();
        }
        public Task<ResultView<CreateUpdateReviews>> Update(CreateUpdateReviews review)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllReviewsDto> GetOne(Guid ID)
        {
            var onePatient = await _reviewRepository.GetByIdAsync(ID);
            var Patient =   new GetAllReviewsDto
            {
                Id = onePatient.Id,
                Comment = onePatient.Comment,
                Rateing = onePatient.Rating,
                DoctorName = onePatient.Doctor?.UserName ?? "Unknown Doctor",
                PatientName = onePatient.Patient?.UserName ?? "Unknown Patient"
            };
                //= _mapper.Map<GetAllReviewsDto>(onePatient);
            return Patient;
        }

        public async Task<int> SaveShanges()
        {
            return await _reviewRepository.SaveChangesAsync();
        }
    }
}
