using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Treatment
{
    public class GetAllTreatment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal NewPrice { get; set; }
        public string SubSpecializationName { get; set; }

        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; } 
    }
}
