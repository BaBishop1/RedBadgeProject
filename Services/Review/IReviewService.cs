using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Reviews;

namespace webapi.Services.Review
{
    public interface IReviewService
    {
        Task<bool> CreateReviewAsync(ReviewCreate model);
        Task<ReviewDetail> GetReviewByIdAsync(int reviewId);
        Task<IEnumerable<ReviewListItem>> GetReviewListByGameIdAsync(int gameId);
        Task<bool> UpdateReviewInfoAsync(ReviewUpdate model);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
