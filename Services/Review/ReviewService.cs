using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Reviews;
using webapi.webapi.Data;
using webapi.Data.Entities;
using webapi.Models.Reviews;

namespace webapi.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _dbcontext;

        public ReviewService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CreateReviewAsync(ReviewCreate model)
        {
            ReviewEntity doesExist = await _dbcontext.Reviews.FirstOrDefaultAsync(x => x.ReviewText == model.ReviewText);
            if (doesExist != null)
            {
                return false;
            }
            ReviewEntity reviewEntity = new ReviewEntity
            {
                GameId = model.GameId,
                GameScore = model.GameScore,
                ReviewText = model.ReviewText,
            };
            _dbcontext.Reviews.Add(reviewEntity);
            int numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<ReviewDetail> GetReviewByIdAsync(int reviewId)
        {
            ReviewEntity review = await _dbcontext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == reviewId);
            if (review == null)
            {
                return null;
            }
            ReviewDetail ReviewDetail = new ReviewDetail
            {
                ReviewId = review.ReviewId,
                GameId = review.GameId,
                GameScore = review.GameScore,
                ReviewText = review.ReviewText,            
            };
            return ReviewDetail;
        }

        public async Task<IEnumerable<ReviewListItem>> GetReviewListByGameIdAsync(int gameId)
        {
            IEnumerable<ReviewListItem> reviews = await _dbcontext.Reviews.Select(review => new ReviewListItem
            {
                ReviewId = review.ReviewId,
                GameId = review.GameId,
                GameScore = review.GameScore,
            }).ToListAsync();
            return reviews;
        }

        public async Task<bool> UpdateReviewAsync(int reviewId, ReviewUpdate model)
        {
            ReviewEntity review = _dbcontext.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            if (review == null)
            {
                return false;
            }
            else
            {
                review.GameScore = model.GameScore;
                review.ReviewText = model.ReviewText;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            ReviewEntity review = _dbcontext.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            if (review == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Reviews.Remove(review);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
