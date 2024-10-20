using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace MedicalWebsite.DTOS.Appointment
{
    public class CreatorUpdateAppointment
    {
        //public Guid Id { get; set; }
        public DateTime Time { get; set; }
        //public string Day { get; set; }
        //public string Location { get; set; }
        public Boolean Status { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }

    }
}
