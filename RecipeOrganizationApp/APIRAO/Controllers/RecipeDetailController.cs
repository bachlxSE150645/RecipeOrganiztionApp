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

        public RecipeDetailController(IRecipeDetailRepository _recipeDetailRepository)
        {
           this.recipeDetailRepo = _recipeDetailRepository;
        }

        [HttpGet("{RecipeId}")]
        public async Task<IActionResult> GetRecipeDetailsByRecipeID(Guid RecipeId)
        {
            try
            {
                return Ok(recipeDetailRepo.GetRecipeDetailsByRecipeId(RecipeId));
            }
            catch
            {
                return BadRequest();
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
