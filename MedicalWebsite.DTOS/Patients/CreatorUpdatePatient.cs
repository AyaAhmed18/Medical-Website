using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace MedicalWebsite.DTOS.Patients
{
    public enum Gender
    {
        Male,
        Female,
    }
    public class CreatorUpdatePatient
    {
         //public String? Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string? Address { get; set; }
        public bool? insurance { get; set; }
        public string Phone { get; set; }
       
        [Required]
        [MinLength(8)]
        public string password { get; set; }
        [Required, Compare("password"), DataType(DataType.Password),
          Display(Name = "Confirm password")]
        public string confirmPassword { get; set; }


        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Only Gmail addresses are allowed.")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        //public Gender Gender { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
    }
}
