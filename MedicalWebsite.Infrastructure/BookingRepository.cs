using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Context;
using MedicalWebsite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Infrastructure
{
    public class BookingRepository : Repository<Booking, int>, IBookingRepository
    { 
        public BookingRepository(MedicalContext medicalContext) : base(medicalContext) { }
    
    }
}
