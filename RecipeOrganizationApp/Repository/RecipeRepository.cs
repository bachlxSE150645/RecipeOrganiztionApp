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
    public class RecipeRepository : IRecipeRepository
    {
        public List<Recipe> GetRecipes() => RecipeDAO.GetRecipes();
        public Recipe GetRecipesById(string id) => RecipeDAO.GetRecipesById(id);
        public void AddRecipe(Recipe recipe) => RecipeDAO.AddRecipe(recipe);
        public void UpdateRecipe(Recipe recipe) => RecipeDAO.UpdateRecipe(recipe);
        public void DeleteRecipe(Recipe recipe) => RecipeDAO.DeleteRecipe(recipe);
    }
}
