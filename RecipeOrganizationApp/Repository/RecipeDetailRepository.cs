using BusinessObjects;
using BusinessObjects.MapData;
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
        public RecipeDetailRepository(AppDBContext dbContext)
        {
            _context = RecipeDetailDAO.GetInstance(dbContext);
        }

        private readonly RecipeDetailDAO _context;

        public List<RecipeDetail> GetRecipeDetails() => RecipeDetailDAO.GetRecipeDetails();
        public List<RecipeDetail> GetRecipeDetailsByRecipeId(string recipeId) => RecipeDetailDAO.GetRecipeDetailsByRecipeId(recipeId);
        public List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId) => RecipeDetailDAO.GetRecipeDetailsByIngredientId(ingredientId);
        public RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId) => RecipeDetailDAO.GetRecipeDetailsByRecIdAndIngId(recId, IngId);
        public Task<RecipeDetail> AddRecipeDetail(RecipeDetailData recipeDetail) => _context.AddRecipeDetail(recipeDetail);
        public void UpdateRecipeDetail(RecipeDetail recipeDetail) => RecipeDetailDAO.UpdateRecipeDetail(recipeDetail);
        public void DeleteRecipeDetail(RecipeDetail recipeDetail) => RecipeDetailDAO.DeleteRecipeDetail(recipeDetail);
    }
}
