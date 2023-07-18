using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Repository.DTOs.Recipe;
using BusinessObjects.MapData;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;
        private readonly IRecipeDetailRepository detailRepo;
        private readonly IMealRepository mealRepo;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository _recipeRepository, IRecipeDetailRepository _detailRepo, IMealRepository _mealRepository,IMapper mapper)
        {
            this.recipeRepo = _recipeRepository;
            this.detailRepo = _detailRepo;
            this.mealRepo = _mealRepository;
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
                var recipe = recipeRepo.GetRecipesById(RecipeId);
                var meal = mealRepo.GetMealsById(RecipeId);
                if (meal != null)
                {
                    var recipeMeal = _mapper.Map<RecipeMealDTO>(meal);
                    recipe.Meal = recipeMeal;
                }
                return Ok(recipe);
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
            recipe.Status = "waiting";
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
        public async Task<IActionResult> UpdateRecipe(Guid Recipeid, [FromBody] UpdateRecipeDTO dto)
        {
            var result = await recipeRepo.UpdateRecipe(Recipeid, dto);
            var current = recipeRepo.GetRecipesById(Recipeid);
            if(current == null)
            {
                return BadRequest();
            }

            foreach (var detail in current.RecipeDetails)
            {
                Console.WriteLine(detail);
                if (detail != null)
                {
                   detailRepo.DeleteRecipeDetail(detail);
                }
            }
            foreach (var newDetail in dto.Ingredients)
            {
                var detail = _mapper.Map<RecipeDetail>(newDetail);
                detail.RecipeID = result.RecipeID;
                await detailRepo.AddRecipeDetail(detail);
            }
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("{status}/StatusOrder(watting,removed...)")]
        public async Task<IActionResult>GetAllRecipeWattingByUser(string status)
        {
                List<Recipe> recipes= recipeRepo.GetAllRecipeWattingByUser(status);
                return Ok( Task.FromResult(recipes));
  
        }
    }
}
