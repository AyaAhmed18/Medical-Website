using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Offers
{
    public class GetAllOffers
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } 
        public decimal? Discount { get; set; }
        public string SpecializationName { get; set; } 
        public string DoctorName { get; set; }
      
    }
}
