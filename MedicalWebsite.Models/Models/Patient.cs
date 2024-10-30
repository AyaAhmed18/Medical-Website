using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Patient :User
    {
        //public string Name { get; set; }
        public string Phone { get; set; }
        public Boolean Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? insurance { get; set; }
        public string?  Adress  { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
