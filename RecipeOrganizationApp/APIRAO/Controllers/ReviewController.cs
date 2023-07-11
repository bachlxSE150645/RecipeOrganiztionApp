using BusinessObjects.MapData;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository reviewRepo;

        public ReviewController(IReviewRepository _reviewRepository)
        {
            reviewRepo = _reviewRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReview()
        {
            try
            {
                return Ok(reviewRepo.GetAllReview());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("{ReviewId}/getByReviewID")]
        public async Task<IActionResult> GetReviewByID(Guid ReviewId)
        {
            try
            {
                return Ok(reviewRepo.GetReviewById(ReviewId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{RecipeId}/getByRecipeID")]
        public async Task<IActionResult> GetReviewByRecipeID(Guid RecipeId)
        {
            try
            {
                return Ok(reviewRepo.GetReviewByRecipe(RecipeId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(ReviewData inf)
        {
            var result = reviewRepo.AddReview(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

        [HttpPut("{ReviewId}")]
        public async Task<IActionResult> UpdateReviewl(Guid ReviewId, string? newContent, float rating)
        {
            var result = reviewRepo.UpdateReview(ReviewId,newContent,rating);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{ReviewId}")]
        public async Task<IActionResult> DeleteReview(Guid ReviewId)
        {
            if (reviewRepo.DeleteReview(ReviewId))
            {
                return Ok("Delete Successc");
            }

            return Ok("ID not found!!");
        }

        

    }
}
