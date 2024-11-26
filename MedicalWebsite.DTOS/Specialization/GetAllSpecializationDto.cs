using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Specialization
{
    public class GetAllSpecializationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int? TreatmentCount { get; set; }
    }
}
