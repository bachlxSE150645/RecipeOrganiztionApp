using AutoMapper;
using BusinessObjects;
using BusinessObjects.MapData;
using DataAccess;
using Microsoft.IdentityModel.Tokens;
using Repository.DTOs.Recipe;
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
            Console.WriteLine("count ", details.Count);
            recipe.RecipeDetails = details;

            return recipe;
        } 
        public Task<Recipe> AddRecipe(Recipe recipe) => dao.AddRecipe(recipe);
        public Task<Recipe> UpdateRecipe(Guid id, UpdateRecipeDTO recipe)
        {
            var r = dao.GetRecipesById(id);
            if (!String.IsNullOrEmpty(recipe.Description))
            {
                r.Description = recipe.Description;
            }
            if (!String.IsNullOrEmpty(recipe.RecipeImage))
            {
                r.RecipeImage = recipe.RecipeImage;
            }
            if (!String.IsNullOrEmpty(recipe.RecipeName))
            {
                r.RecipeName = recipe.RecipeName;
            }
            
            return dao.UpdateRecipe(id, r);
        }
        public void DeleteRecipe(Recipe recipe) => dao.DeleteRecipe(recipe);

        public void UpdateContributerApprove(Recipe recipe) => dao.UpdateContributerApprove(recipe);

        public List<Recipe> GetAllRecipeWattingByUser(string status)
        {
            List<Recipe> recipes = this.dao.GetAllRecipeWattingByUser(status);

            foreach (Recipe recipe in recipes)
            {
                recipe.RecipeDetails = detailDAO.GetRecipeDetailsByRecipeId(recipe.RecipeID);
            }
            return recipes;
        }
    }
}
