using BusinessObjects;
using BusinessObjects.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRecipeDetailRepository
    {
        List<RecipeDetail> GetRecipeDetails();
        List<RecipeDetail> GetRecipeDetailsByRecipeId(string recipeId);
        List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId);
        RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId);
        Task<RecipeDetail> AddRecipeDetail(RecipeDetailData recipeDetail);
        void UpdateRecipeDetail(RecipeDetail recipeDetail);
        void DeleteRecipeDetail(RecipeDetail recipeDetail);
    }
}
