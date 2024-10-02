using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Appointment: BaseEntity
    {

        public DateTime BookngTime { get; set; }
        public Boolean Status { get; set; }  //confirmed , cancelled
        public int payment { get; set; } //cash , paypal , mobile wallet\
       
        // Foreign Keys   
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
