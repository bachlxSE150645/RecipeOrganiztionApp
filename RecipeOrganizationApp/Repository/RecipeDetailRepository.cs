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
            dao = new RecipeDetailDAO(dbContext);
        }

        private readonly RecipeDetailDAO dao;

        public List<RecipeDetail> GetRecipeDetails() => dao.GetRecipeDetails();
        public List<RecipeDetail> GetRecipeDetailsByRecipeId(Guid recipeId) => dao.GetRecipeDetailsByRecipeId(recipeId);
        public List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId) => dao.GetRecipeDetailsByIngredientId(ingredientId);
        public RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId) => dao.GetRecipeDetailsByRecIdAndIngId(recId, IngId);
        public Task<RecipeDetail> AddRecipeDetail(RecipeDetail recipeDetail) => dao.AddRecipeDetail(recipeDetail);
        public void UpdateRecipeDetail(RecipeDetail recipeDetail) => dao.UpdateRecipeDetail(recipeDetail);
        public void DeleteRecipeDetail(RecipeDetail recipeDetail) => dao.DeleteRecipeDetail(recipeDetail);
    }
}
