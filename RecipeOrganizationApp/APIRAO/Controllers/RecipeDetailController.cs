using BusinessObjects.MapData;
using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeDetailController : ControllerBase
    {
        private readonly IRecipeDetailRepository recipeDetailRepo;

        public RecipeDetailController(AppDBContext dbContext)
        {
            recipeDetailRepo = new RecipeDetailRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetDetail()
        {
            try
            {
                return Ok(recipeDetailRepo.GetRecipeDetails());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostRecipeDetail(RecipeDetailData inf)
        {
            var result = await recipeDetailRepo.AddRecipeDetail(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
    }
}
