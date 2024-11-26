using MedicalWebsite.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.Applicationn.Contract
{
    public interface ITreatmentRepository : IRepository<Treatment, Guid>
    {
        Task<IQueryable<Treatment>> GetTreatmentsWithIncludesAsync();

    }
}
