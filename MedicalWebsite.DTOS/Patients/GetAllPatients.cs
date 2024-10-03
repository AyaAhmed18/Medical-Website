using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalWebsite.DTOS.Patients
{
    public class GetAllPatients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
        
        public DateOnly? BirthDate { get; set; }
        public Gender? Gender { get; set; }
       
    }
}
