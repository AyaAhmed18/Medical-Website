using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class SubSpecialization:BaseEntity
    {
        public  string Name{ get; set; }
        public virtual ICollection<Treatment>? Treatments { get; set; }
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

    }
}
