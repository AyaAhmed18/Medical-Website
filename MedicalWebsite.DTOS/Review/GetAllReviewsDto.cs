﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.Review
{
    public class GetAllReviewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string review { get; set; }
        public int? Rate { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}