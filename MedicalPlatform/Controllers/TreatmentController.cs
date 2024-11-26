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
using MedicalWebsite.DTOS.Treatment;
using System.Runtime.InteropServices;
namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }
       // With 1img
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateTreatment([FromForm] CreateUpdateTreatment treatment, IFormFile imageFile)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new
        //        {
        //            IsSuccess = false,
        //            Message = "Invalid model state."
        //        });
        //    }

        //    var result = await _treatmentService.Create(treatment, imageFile);

        //    if (result.IsSuccess)
        //    {
        //        return Ok(new
        //        {
        //            result.IsSuccess,
        //            result.Message,
        //            result.Entity
        //        });
        //    }

        //    return BadRequest(new
        //    {
        //        result.IsSuccess,
        //        result.Message
        //    });
        //}

        [HttpPost("create")]
        public async Task<IActionResult> CreateTreatment([FromForm] CreateUpdateTreatment treatment, [FromForm] IEnumerable<IFormFile> imageFiles)
        {

          
            try
            {
                var result = await _treatmentService.Create(treatment, imageFiles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new
            //    {
            //        IsSuccess = false,
            //        Message = "Invalid model state."
            //    });
            //}

            //if (result.IsSuccess)
            //{
            //    return Ok(new
            //    {
            //        result.IsSuccess,
            //        result.Message,
            //        result.Entity
            //    });
            //}

            //return BadRequest(new
            //{
            //    result.IsSuccess,
            //    result.Message
            //});
        }


        //no imge
        //[HttpPost("CreateTreatment")]
        //public async Task<IActionResult> CreatTreatment([FromBody] CreateUpdateTreatment Treatment)
        //{
        //    try
        //    {
        //        var result = await _treatmentService.Create(Treatment);
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



        [HttpGet("GetAllTreatments")]
        public async Task<IActionResult> GetAllTreatment(int pageSize, int pageNumber = 1)
        {
            try
            {
                var offer = await _treatmentService.GetAllPagination(pageSize, pageNumber);

                return Ok(offer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpGet("GetTopTreatment")]
        //public async Task<IActionResult> GetTopTreatments(int pageSize, int pageNumber = 1)
        //{
        //    try
        //    {
        //        var offer = await _treatmentService.GetTopPagination(pageSize, pageNumber);

        //        return Ok(offer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpGet("Get1TopTreatmentInSubspalisations")]
        public async Task<IActionResult> GetTopTreatmentInSubspalisation()
        {
            try
            {
                var offer = await _treatmentService.GetTopTreatmentsInSubSpecialization();

                return Ok(offer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("GetTreatmentById/{id}")]
        public async Task<IActionResult> GetTreatmentById(Guid id)
        {
            var result = await _treatmentService.GetTreatmentById(id);
            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
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

