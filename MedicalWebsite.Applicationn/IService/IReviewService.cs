using MedicalWebsite.DTOS.Review;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vezeeta.Application.Iservices
{
    public interface IReviewService
    {
        Task<ResultView<CreateUpdateReviews>> Create(CreateUpdateReviews review);
        Task<ResultView<GetAllReviewsDto>> SoftDelete(GetAllReviewsDto review);
        Task<ResultView<CreateUpdateReviews>> HardDelete(CreateUpdateReviews review);
        Task<ResultDataList<GetAllReviewsDto>> GetAllPagination(int items, int pagenumber);
        Task<ResultDataList<GetAllReviewsDto>> GetHighRate(int items, int pagenumber);

        Task<GetAllReviewsDto> GetOne(int ID);
        Task<ResultView<CreateUpdateReviews>> Update(CreateUpdateReviews review);

        Task<int> SaveShanges();
    }
}
