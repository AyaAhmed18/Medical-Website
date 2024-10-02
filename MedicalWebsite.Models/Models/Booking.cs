using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Models.Models
{
    public class Booking:BaseEntity
    {
        public string? fees { get; set; }
        public TimeOnly? watingTime { get; set; }
        public DayOfWeek? StartDay { get; set; }
        public DayOfWeek? EndDay { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }

        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
