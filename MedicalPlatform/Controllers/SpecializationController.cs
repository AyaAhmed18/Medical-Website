using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vezeeta.Application.Iservices;

namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpeciallizationService _speciallizationService;

        public SpecializationController(ISpeciallizationService speciallizationService)
        {
            _speciallizationService = speciallizationService;
        }
        // GET: api/<TopicController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Specs = (await _speciallizationService.GetAllSpecsAsync());
            if (Specs != null)
                return Ok(Specs.Entities);
            else
                return Ok(null);
        }

    }
}
