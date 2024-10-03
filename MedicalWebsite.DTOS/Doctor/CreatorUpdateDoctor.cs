using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MedicalWebsite.DTOS.Doctor
{
    public class CreatorUpdateDoctor
    {
        public int Id { get; set; }
        public string FirstNameEn { get; set; }
        public string FirstNameAr { get; set; }
        public string LastNameEn { get; set; }
        public string LastNameAr { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string EducationEn { get; set; }
        public string EducationAr { get; set; }
        public string Email { get; set; }
        public string BackGroundEn { get; set; }
        public string BackGroundAr { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Fees { get; set; }
        public TimeOnly WaitingTime { get; set; }
        public byte[] Image { get; set; }
        
    }
}
