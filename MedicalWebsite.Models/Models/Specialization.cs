using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
   
    public class Specialization : BaseEntity
    {
        public string Title { get; set; }

        //------------ one-to-many with doctor
        public virtual ICollection<Doctor>? Doctors { get; set; }

        //-------- one-to-one with offers 
        public Offers? Offer { get; set; }

        //------- one-to-many with Treatment
        //public virtual ICollection<Treatment>? Treatment { get; set; }
        //------- one-to-many with SubSpecialization
        public virtual ICollection<SubSpecialization>? SubSpecializations { get; set; }

    }

}
