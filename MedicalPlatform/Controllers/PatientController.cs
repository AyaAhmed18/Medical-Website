using MedicalWebsite.Applicationn.Service;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalWebsite.Applicationn.IService;
using MedicalWebsite.DTOS.Doctor;
using MedicalWebsite.DTOS.User;
namespace MedicalPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpGet("AllPatients/{items}/{pageNumber}")]
        public async Task<IActionResult> AllPatientsPages(int items, int pageNumber = 1)
        {
            try
            {
                var users = await _patientService.GetAllPatientsPages(items, pageNumber);
                if (users.Count > 0)
                {
                    return Ok(users);
                }
                else
                {
                    return Problem(statusCode: 400, title: "Failed to get paginated users");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting paginated users");
                return StatusCode(500, "An internal server error occurred");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var topic = (await _patientService.GetPatientById(id));
            if (topic != null)
                return Ok(topic);
            else
                return Ok(null);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(GetAllPatients patientDTO)
        {

            if (ModelState.IsValid)
            {
                var Updatedpatient = await _patientService.UpdatePatient(patientDTO);
                if (Updatedpatient.IsSuccess)
                    return Ok(Updatedpatient.Entity);
                else
                    return BadRequest(Updatedpatient.Message);

            }
            else
                return BadRequest("InValid Data");
        }

        [HttpDelete("Block/{id}")]//delet???????
        public async Task<IActionResult> Delete(string id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient != null)
            {
                var deletedpatient = await _patientService.HardDeletePatient(id);
                if (deletedpatient.IsSuccess)
                    return Ok(patient);
                else return BadRequest(deletedpatient.Message);
            }
            return BadRequest("topic Not found");
        }

        [HttpDelete("{id}")]//blok????????
        public async Task<IActionResult> Block(string id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient != null)
            {
                var deletedpatient = await _patientService.BlockPatient(id);
                if (deletedpatient.IsSuccess)
                    return Ok(patient);
                else return BadRequest(deletedpatient.Message);
            }
            return BadRequest("patient Not found");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreatorUpdatePatient account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _patientService.RegisterAsPatient(account);

                    if (result.IsSuccess)
                    {
                        return Ok(new { message = "Registration successful. Please confirm your email." });

                    }
                    else
                    {
                        var errors = ModelState.Values.SelectMany(v => v.Errors)
                                  .Select(e => e.ErrorMessage)
                                  .ToList();
                        _logger.LogError("Model validation failed: {Errors}", string.Join(", ", errors));
                        return BadRequest(new { message = "Validation failed", errors });
                        //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                        //return BadRequest(new { message = "Validation failed", errors });

                        //return Problem(statusCode: 400, title: "Registration Failed", detail: result.Message);
                    }
                }
                
                 

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during registration");
                return StatusCode(500, "An internal server error occurred");
            }
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)

        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid email confirmation request.");
            }

            var result = await _patientService.ConfirmEmailAsync(userId, token);

            if (result.Succeeded)
            {
                return Ok(new { message = "Email confirmed successfully!" });
            }

            return BadRequest(result.Errors);
        }

        //    [HttpGet("GettAllPatients")]
        //    public async Task<IActionResult> GettAllPatients(int pageNumber = 1)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var pageSize = 2;
        //        var productsDataList = await _patientService.GetAllPagination(pageSize, pageNumber);
        //        return Ok(productsDataList);

        //    }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetAppointment(GetAllPatients patient)
        //    {
        //        try
        //        {
        //            var gpatient = await _patientService.GetOne(patient.Id);
        //            return Ok(gpatient);
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, ex.Message);
        //        }
        //    }
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeletPatient(string id)
        //    {
        //        try
        //        {
        //            var patient = await _patientService.GetOne(id);
        //            var result = await _patientService.SoftDelete(patient);
        //            return Ok("Patient Deleted  successfully.");
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(500, ex.Message);
        //        }
        //    }
        //    //[HttpPost("Create")]
        //    //public async Task<IActionResult> Create([FromBody] CreatorUpdatePatient patient)
        //    //{
        //    //    if (!ModelState.IsValid)
        //    //    {
        //    //        return BadRequest(ModelState);
        //    //    }

        //    //    var result = await _patientService.Create(patient);

        //    //    if (!result.IsSuccess)
        //    //    {
        //    //        return BadRequest(result.Message);
        //    //    }

        //    //    return Ok(result.Entity);
        //    //}
        //}
    }
}
