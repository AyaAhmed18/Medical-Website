using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Treatment
{
    public class CreateUpdateTreatment
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string? Image { get; set; }
        public decimal? Discount { get; set; }
        public Guid SubSpecializationId { get; set; } 
        public Guid DoctorId { get; set; }
    }
}
