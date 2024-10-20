using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Review
{
    public class CreateUpdateReviews
    {
        //public Guid Id { get; set; }
        //public string Title { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }
        public int PatientID { get; set; }
        public int DoctorId { get; set; }
    }
}
