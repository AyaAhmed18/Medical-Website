using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Review
{
    public class CreateUpdateReviews
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string review { get; set; }
        public int? Rate { get; set; }
        public int PatientID { get; set; }
        public int DoctorId { get; set; }
    }
}
