using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models.Reviews;
using webapi.Models.Reviews;
using webapi.Services.Review;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly ITokenService _tokenService;

        public ReviewController(IReviewService reviewService, ITokenService tokenService)
        {
            _reviewService = reviewService;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createReview = await _reviewService.CreateReviewAsync(model);
            if (createReview == true)
            {
                return Ok("Review Creation Sucessful");
            }
            else
            {
                return BadRequest("Review Creation Failed");
            }
        }
        [HttpGet("ReviewList")]
        public async Task<IActionResult> GetReviewList(int gameId)
        {
            IEnumerable<ReviewListItem> reviews = await _reviewService.GetReviewListByGameIdAsync(gameId);
            return Ok(reviews);
        }
        [HttpGet("{reviewId:int}")]
        public async Task<IActionResult> GetReviewById([FromRoute] int ReviewId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ReviewDetail reviewDetail = await _reviewService.GetReviewByIdAsync(ReviewId);
            if (reviewDetail is null)
            {
                return NotFound();
            }
            return Ok(reviewDetail);
        }
        [HttpPut("{reviewId:int}")]
        public async Task<IActionResult> UpdateReviewById([FromRoute] int reviewId, [FromBody] ReviewUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _reviewService.UpdateReviewAsync(reviewId, model)
                ? Ok("Review Was Updated")
                : BadRequest(ModelState);
        }
        [HttpDelete("{reviewId:int}")]
        public async Task<IActionResult> DeleteReviewById([FromRoute] int reviewId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _reviewService.DeleteReviewAsync(reviewId)
                ? Ok("Review was Deleted")
                : BadRequest(ModelState);
        }
    }
}
