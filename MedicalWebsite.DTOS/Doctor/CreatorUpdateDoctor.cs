using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MedicalWebsite.DTOS.Doctor
{
    public class CreatorUpdateDoctor
    {
        public String Id { get; set; }
        public string UserName { get; set; }
        public string? Title { get; set; }
        public string Phone { get; set; }
        public string? Education { get; set; }
        public string? Adress { get; set; }
        public string? Image { get; set; }
        public Boolean Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid SpecializationId { get; set; }


    }
}
