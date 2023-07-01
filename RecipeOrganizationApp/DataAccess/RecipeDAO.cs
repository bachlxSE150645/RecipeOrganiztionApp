using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RecipeDAO
    {
        private readonly AppDBContext _context;

        public RecipeDAO (AppDBContext dbContext)
        {
            this._context = dbContext;
        }


        //Get All Recipes
        public List<Recipe> GetRecipes()
        {
            var listRecipes = new List<Recipe>();
            try
            {
                listRecipes = this._context.Recipes.Include(r => r.Account).ToList();
            } catch(Exception ex)
            {
                throw ex;
            }
            return listRecipes;
        }
        //Get Recipe matches RecipeID
        public  Recipe GetRecipesById(string id)
        {
            var recipe = new Recipe();
            try
            {
                recipe = this._context.Recipes.Where(x => x.RecipeID.Equals(id)).Include(r => r.Account).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recipe;
        }

        //Post new Recipe
        public async Task<Recipe> AddRecipe(RecipeData recipe)
        {
            try
            {
                var recipeAdd = new Recipe
                {
                    RecipeID = Guid.NewGuid(),
                    RecipeName = recipe.RecipeName,
                    RecipeImage = recipe.RecipeImage,
                    Description = recipe.Description,
                    AccountID = recipe.AccountID,
                    Status = "waitting",
                    CreateDate = DateTime.Now
                };
                this._context.Recipes.Add(recipeAdd);
                await this._context.SaveChangesAsync();
                return recipeAdd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Recipe
        public void UpdateRecipe(Recipe recipe)
        {
            try
            {
                var recipeCheck = this._context.Recipes.SingleOrDefault(x => x.RecipeID == recipe.RecipeID);
                if (recipeCheck != null)
                {
                    this._context.Entry<Recipe>(recipe).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    this._context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Recipe
        public void DeleteRecipe(Recipe recipe)
        {
            try
            {
                var recipeCheck = this._context.Recipes.SingleOrDefault(x => x.RecipeID.Equals(recipe.RecipeID));
                if (recipeCheck != null)
                {
                    this._context.Recipes.Remove(recipeCheck);
                    this._context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}