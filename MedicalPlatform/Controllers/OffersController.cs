using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.Models.Models;
using MedicalWebsite.DTOS.Offers;
using MedicalWebsite.DTOS.Review;
namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            _offersService = offersService;
        }
        [HttpPost("CreateOffer")]
        public async Task<IActionResult> CreateOffer([FromBody] CreateUpdateOffers offer)
        {
            try
            {
                var result = await _offersService.CreateOffer(offer);
                if (result.IsSuccess)
                {
                    return Ok(result.Entity);
                }
                return BadRequest(result.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpGet("GetAllOffers")]
        public async Task<IActionResult> GetAllOffers(int pageSize, int pageNumber = 1)
        {
            try
            {
                var offer = await _offersService.GetAllPagination(pageSize, pageNumber);

                return Ok(offer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetTopOffers")]
        public async Task<IActionResult> GetTopOffers(int pageSize, int pageNumber = 1)
        {
            try
            {
                var offer = await _offersService.GetTopPagination(pageSize, pageNumber);

                return Ok(offer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOffer(Guid id, [FromBody] CreateUpdateOffers offer)
        //{
        //    try
        //    {
        //        var result = await _offersService.Update(id, offer);
        //        if (result.IsSuccess)
        //        {
        //            return Ok(result.Entity);
        //        }
        //        return BadRequest(result.Message); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message); 
        //    }
        //}


    }

}

