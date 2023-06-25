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

        public List<Recipe> GetRecipes() => dao.GetRecipes();
        public Recipe GetRecipesById(string id) => dao.GetRecipesById(id);
        public Task<Recipe> AddRecipe(RecipeData recipe) => dao.AddRecipe(recipe);
        public void UpdateRecipe(Recipe recipe) => dao.UpdateRecipe(recipe);
        public void DeleteRecipe(Recipe recipe) => dao.DeleteRecipe(recipe);
    }
}
