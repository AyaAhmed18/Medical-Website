﻿using MedicalWebsite.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Doctor { 
    public class GetAllDoctors:UserDTO
    {
       public  GetAllDoctors()
        {
            
        }
        public string UserName { get; set; }
        public string? Title { get; set; }
      //  public string Phone { get; set; }
        public string? Education { get; set; }
        public string? Address { get; set; }
        public String? Image { get; set; }
        public  Boolean Gender { get; set; }
        public string GenderR {
            get
            {
                return Gender ? "Male" : "Female";
            }
            set { } } 
        public string Email { get; set; }
       
        public String Specialization { get; set; }

       
    }
}
