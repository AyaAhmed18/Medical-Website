using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.User
{
    public class MailDTO
    {
        public string? callBackUrl { get; set; }
        public string? userName { get; set; }
        public string? phoneNumber { get; set; }
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? password { get; set; }
        public string? confirmPassword { get; set; }
    }
}
