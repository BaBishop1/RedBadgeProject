using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Reviews;

namespace webapi.Services.Review
{
    public class ReviewService : IReviewService
    {
        public Task<bool> CreateReviewAsync(ReviewCreate model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReviewAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDetail> GetReviewByIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewListItem>> GetReviewListByGameIdAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReviewInfoAsync(ReviewUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
