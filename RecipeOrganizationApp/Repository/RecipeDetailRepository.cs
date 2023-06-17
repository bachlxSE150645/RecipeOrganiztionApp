using BusinessObjects;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RecipeDetailRepository : IRecipeDetailRepository
    {
        public List<RecipeDetail> GetRecipeDetails() => RecipeDetailDAO.GetRecipeDetails();
        public List<RecipeDetail> GetRecipeDetailsByRecipeId(string recipeId) => RecipeDetailDAO.GetRecipeDetailsByRecipeId(recipeId);
        public List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId) => RecipeDetailDAO.GetRecipeDetailsByIngredientId(ingredientId);
        public RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId) => RecipeDetailDAO.GetRecipeDetailsByRecIdAndIngId(recId, IngId);
        public void AddRecipeDetail(RecipeDetail recipeDetail) => RecipeDetailDAO.AddRecipeDetail(recipeDetail);
        public void UpdateRecipeDetail(RecipeDetail recipeDetail) => RecipeDetailDAO.UpdateRecipeDetail(recipeDetail);
        public void DeleteRecipeDetail(RecipeDetail recipeDetail) => RecipeDetailDAO.DeleteRecipeDetail(recipeDetail);
    }
}
