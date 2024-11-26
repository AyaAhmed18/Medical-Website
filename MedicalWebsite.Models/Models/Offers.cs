using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
   
    public class Offers : BaseEntity
    {

        public string Name { get; set; }
        public decimal? Discount { get; set; }
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
       
    }

}
