using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Offers
{
    public class CreateUpdateOffers
    {
        public string Name { get; set; } 
        public decimal? Discount { get; set; } 
        public Guid SpecializationId { get; set; } 
        public Guid DoctorId { get; set; }
    }
}
