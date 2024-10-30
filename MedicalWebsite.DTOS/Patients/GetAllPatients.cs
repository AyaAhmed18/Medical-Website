using MedicalWebsite.DTOS.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MedicalWebsite.DTOS.Patients
{
    public class GetAllPatients : UserDTO
    {
        public String Id { get; set; }
        public string UserName { get; set; }
        public string? Adress { get; set; }
        public bool? insurance { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        //public Gender Gender { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
    }
}
