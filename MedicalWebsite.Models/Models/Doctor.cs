using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Doctor:User
    {
       // public string Name { get; set; }
        public string? Title { get; set; }
        public string Phone { get; set; }  /// Delete
        public string? Education { get; set; }
       public string? Adress { get; set; }
        public string? Image { get; set; }
        public Boolean Gender { get; set; }
        public virtual ICollection<Patient>? Patients { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        // Foreign Keys
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public Booking Booking { get; set; }



    }
}
