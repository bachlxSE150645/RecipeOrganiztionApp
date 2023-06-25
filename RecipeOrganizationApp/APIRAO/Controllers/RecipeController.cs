using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BusinessObjects.MapData;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeController(AppDBContext dbContext)
        {
            recipeRepo = new RecipeRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return Ok(recipeRepo.GetRecipes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostRecipe(RecipeData inf)
        {
            var result = await recipeRepo.AddRecipe(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }
    }
}
