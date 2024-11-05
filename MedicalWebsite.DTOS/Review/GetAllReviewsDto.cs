using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Review
{
    public class GetAllReviewsDto
    {
        public Guid Id { get; set; }
        //public string Title { get; set; }
        public string Comment { get; set; }
        public int? Rateing { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
