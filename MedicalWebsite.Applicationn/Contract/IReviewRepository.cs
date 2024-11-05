using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalWebsite.Models;

namespace MedicalWebsite.Applicationn.Contract
{
    public interface IReviewRepository: IRepository<Review, Guid>
    {
    }
}
