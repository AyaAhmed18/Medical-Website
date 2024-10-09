using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Appointment
{
    public class GetAllAppointement
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        //public string Day { get; set; }
        //public string Location { get; set; }
        public Boolean Status { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Payment {  get; set; }
       
    }
}
