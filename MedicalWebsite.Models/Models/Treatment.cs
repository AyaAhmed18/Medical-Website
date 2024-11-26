using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Treatment : BaseEntity
    {
        
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal NewPrice { get; set; }
        public string Image { get; set; }
        //public Guid SpecializationId { get; set; }
        //public Specialization Specialization { get; set; }
        public Guid SubSpecializationId { get; set; }
        public SubSpecialization SubSpecialization { get; set; }

        public Guid DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
        public virtual Doctor Doctor { get; set; }

    }

}
