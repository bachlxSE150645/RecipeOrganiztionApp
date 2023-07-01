using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeController(IRecipeRepository _recipeRepository)
        {
            this.recipeRepo = _recipeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes(string? recipeName = "")
        {
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                return Ok(await recipeRepo.GetRecipes());
            }
            else
            {
                List<Recipe> recipes = recipeRepo.GetRecipeByName(recipeName);
                return Ok(await Task.FromResult(recipes));
            }

        }

        [HttpGet("{RecipeId}")]
        public async Task<IActionResult> GetRecipeByID(Guid RecipeId)
        {
            try
            {
                return Ok(recipeRepo.GetRecipesById(RecipeId));
            }
            catch
            {
                return BadRequest();
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

        [HttpDelete("{RecipeId}")]
        public async Task<IActionResult> DeleteRecipe(Guid RecipeId)
        {
            var rs = recipeRepo.GetRecipesById(RecipeId);
            if(rs == null)
            {
                return BadRequest();
            }
            
            recipeRepo.DeleteRecipe(rs);
            return Ok();
        }

        [HttpPut("{Recipeid}")]
        public async Task<IActionResult> UpdateRecipe(Guid Recipeid, RecipeData rec)
        {
            var result = await recipeRepo.UpdateRecipe(Recipeid, rec);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
