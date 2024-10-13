using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebsite.DTOS.ViewResult
{
    public class ResultDataList<TEntity>
    {
        public List<TEntity> Entities { get; set;}
        public int Count { get; set;}
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? PageSize { get; set; }
        public ResultDataList()
        {
            Entities = new List<TEntity>();
        }

    }
}
