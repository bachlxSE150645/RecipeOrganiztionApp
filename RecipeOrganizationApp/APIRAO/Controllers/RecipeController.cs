using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Repository.DTOs.Recipe;


namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;
        private readonly IRecipeDetailRepository detailRepo;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository _recipeRepository, IRecipeDetailRepository _detailRepo, IMapper mapper)
        {
            this.recipeRepo = _recipeRepository;
            this.detailRepo = _detailRepo;
            this._mapper = mapper;
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
        public async Task<IActionResult> PostRecipe(CreateRecipeDTO dto)
        {
            var recipe = _mapper.Map<Recipe>(dto);
            recipe.Status = "pending";
            try
            {
                if (recipe == null)
                {
                    return BadRequest("Something wrong!");
                }
                else
                {
                    var result = await recipeRepo.AddRecipe(recipe);
                    foreach(var item in dto.Ingredients)
                    {
                        var detail = _mapper.Map<RecipeDetail>(item);
                        if (detail != null) {
                            detail.RecipeID = result.RecipeID;
                            await detailRepo.AddRecipeDetail(detail);
                        }
                    }
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

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
        public async Task<IActionResult> UpdateRecipe(Guid Recipeid, UpdateRecipeDTO dto)
        {
            var result = await recipeRepo.UpdateRecipe(Recipeid, dto);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
