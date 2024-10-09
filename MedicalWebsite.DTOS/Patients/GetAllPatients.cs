using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MedicalWebsite.DTOS.Patients
{
    public class GetAllPatients
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        
        public DateTime? BirthDate { get; set; }
        //public Gender? Gender { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender? Gender { get; set; }
    }
}
