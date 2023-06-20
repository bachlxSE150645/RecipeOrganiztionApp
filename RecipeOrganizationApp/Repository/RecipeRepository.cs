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
            _context = RecipeDAO.GetInstance(dbContext);
        }

        private readonly RecipeDAO _context;

        public List<Recipe> GetRecipes() => RecipeDAO.GetRecipes();
        public Recipe GetRecipesById(string id) => RecipeDAO.GetRecipesById(id);
        public Task<Recipe> AddRecipe(RecipeData recipe) => _context.AddRecipe(recipe);
        public void UpdateRecipe(Recipe recipe) => RecipeDAO.UpdateRecipe(recipe);
        public void DeleteRecipe(Recipe recipe) => RecipeDAO.DeleteRecipe(recipe);
    }
}
