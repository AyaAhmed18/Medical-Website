using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Review: BaseEntity
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int HelpfulVotes { get; set; } = 0;



        // Foreign Keys
        public string DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
