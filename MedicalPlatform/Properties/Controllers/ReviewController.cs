﻿using MedicalWebsite.DTOS.Review;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Iservices;
using MedicalWebsite.Applicationn.IService;
namespace MedicalPlatform.Properties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }


        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] CreateUpdateReviews review)
        {
            try
            {
                
                var result = await _reviewService.Create(review);
                 return Ok(new { message = result.Message, review = result.Entity });
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateReview/{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] CreateUpdateReviews review)
        {
            try
            {
                var result = await _reviewService.Update(review);
                return Ok(new { message = result.Message, review = result.Entity });               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GettAllReviews")]
        public async Task<IActionResult> GetAllReviews(int pageSize, int pageNumber)
        {
            try
            {
                var review = await _reviewService.GetAllPagination(pageSize, pageNumber);
                return Ok(review.Entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetHighRate")]
        public async Task<IActionResult> GetHighRate(int pageSize, int pageNumber)
        {
            try
            {
                var review = await _reviewService.GetHighRate(pageSize, pageNumber);
                return Ok(review.Entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            try
            {
                var review = (await _reviewService.GetOne(id));
                if (review != null)
                {
                    return (Ok(review));
                }
                else
                {
                    return NotFound("this review Not Found");
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletReview(int id)
        {
            try
            {
                var patient = await _reviewService.GetOne(id);
                var result = await _reviewService.SoftDelete(patient);
                return Ok("Review Deleted  successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
   