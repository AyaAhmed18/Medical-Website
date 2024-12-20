﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.User
{
   
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        //public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
     
        public string Role { get; set; }

    }
}
