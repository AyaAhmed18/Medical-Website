using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Context;
using MedicalWebsite.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Infrastructure
{
    public class TreatmentRepository : Repository<Treatment, Guid>, ITreatmentRepository
    {
        public TreatmentRepository(MedicalContext medicalContext):base(medicalContext) { }

        //public async Task<IQueryable<Treatment>> GetTreatmentsWithIncludesAsync()
        //{
        //    return _tEntity
        //        .Include(t => t.Doctor)
        //        .Include(t => t.SubSpecialization);
        //}
        public async Task<IQueryable<Treatment>> GetTreatmentsWithIncludesAsync()
        {
            return await Task.FromResult(
                _tEntity
                    .Include(t => t.Doctor)
                    .Include(t => t.SubSpecialization)
                    .AsQueryable()
            ) ;
        }


    }
}
