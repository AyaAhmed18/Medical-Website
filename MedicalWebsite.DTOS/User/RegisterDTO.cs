using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MedicalWebsite.DTOS.User {
    [NotMapped]
    public class RegisterDTO //: IdentityUser
    {
        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public Boolean Gender { get; set; }
      
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Only Gmail addresses are allowed.")]
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Address { get; set; }

        [Required]
        public string password { get; set; }
        [Required, Compare("password"), DataType(DataType.Password),
          Display(Name = "Confirm password")]
        public string confirmPassword { get; set; }
        public IFormFile? Image { get; set; }
        public string? Imagepath { get; set; }
        public string? Education { get; set; }
        public Guid? SpecializationId { get; set; }
    }
}
