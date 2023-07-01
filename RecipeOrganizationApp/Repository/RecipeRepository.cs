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
        }

        private readonly RecipeDAO dao;

        public Recipe GetRecipeByName(string name) => dao.GetRecipesByName(name);
        public Task<List<Recipe>> GetRecipes() => dao.GetRecipes();
        public Recipe GetRecipesById(Guid id) => dao.GetRecipesById(id);
        public Task<Recipe> AddRecipe(RecipeData recipe) => dao.AddRecipe(recipe);
        public Task<Recipe> UpdateRecipe(Guid id, RecipeData recipe) => dao.UpdateRecipe(id,recipe);
        public void DeleteRecipe(Recipe recipe) => dao.DeleteRecipe(recipe);
    }
}
