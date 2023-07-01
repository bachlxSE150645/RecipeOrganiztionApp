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
    public class RecipeRepository : IRecipeRepository
    {
        public RecipeRepository(AppDBContext dbContext)
        {
            dao = new RecipeDAO(dbContext);
            detailDAO = new RecipeDetailDAO(dbContext);
        }

        private readonly RecipeDAO dao;
        private readonly RecipeDetailDAO detailDAO;

        public List<Recipe> GetRecipeByName(string name)
        {
            List<Recipe> recipes = this.dao.GetRecipesByName(name);

            foreach (Recipe recipe in recipes)
            {
                recipe.RecipeDetails = detailDAO.GetRecipeDetailsByRecipeId(recipe.RecipeID);
            }

            return recipes;
        }

        public Task<List<Recipe>> GetRecipes() => dao.GetRecipes();
        public Recipe GetRecipesById(Guid id) {
            Recipe recipe = this.dao.GetRecipesById(id);

            var details = detailDAO.GetRecipeDetailsByRecipeId(recipe.RecipeID);
            recipe.RecipeDetails = details;

            return recipe;
        } 
        public Task<Recipe> AddRecipe(RecipeData recipe) => dao.AddRecipe(recipe);
        public Task<Recipe> UpdateRecipe(Guid id, RecipeData recipe) => dao.UpdateRecipe(id,recipe);
        public void DeleteRecipe(Recipe recipe) => dao.DeleteRecipe(recipe);
    }
}
