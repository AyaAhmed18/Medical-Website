using MedicalWebsite.DTOS.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Specialization
{
    public class GetAllSubSpecializationDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid SpecializationId { get; set; }
        public string? SpecializationName { get; set; }
       // public List<GetAllTreatment>? Treatments { get; set; }
        public List<GetAllTreatment>? Treatments { get; set; } = new List<GetAllTreatment>();
    }
}
