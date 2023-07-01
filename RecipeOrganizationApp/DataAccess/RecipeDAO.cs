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
        public async Task<List<Recipe>> GetRecipes()
        {
            var listRecipes = new List<Recipe>();
            try
            {
                listRecipes = this._context.Recipes.Include(c => c.Account).Include(c => c.Account.Role).ToList();
            } catch(Exception ex)
            {
                throw ex;
            }
            return listRecipes;
        }
        //Get Recipe matches RecipeID
        public  Recipe GetRecipesById(Guid id)
        {
            var recipe = new Recipe();
            try
            {
                recipe = this._context.Recipes
                    .Include(c => c.Account)
                    .Include(c => c.Account.Role)
                    .Where(x => x.RecipeID.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recipe;
        }
        //Get By Name
        public Recipe GetRecipesByName(string name)
        {
            var recipe = new Recipe();
            try
            {
                recipe = this._context.Recipes
                    .Include(c => c.Account)
                    .Include(c => c.Account.Role)
                    .Where(x => x.RecipeName.Contains(name)).SingleOrDefault();
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
                    CreateDate = DateTime.Now,
                    Account = await _context.Accounts.FirstOrDefaultAsync(c => c.AccountID == recipe.AccountID)

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
        public async Task<Recipe> UpdateRecipe(Guid id,RecipeData rec)
        {
            try
            {

                var recipe = this._context.Recipes
                    .Include(c => c.Account)
                    .Include(c => c.Account.Role)
                    .Where(x => x.RecipeID.Equals(id)).SingleOrDefault();

                recipe.RecipeName = rec.RecipeName;
                recipe.RecipeImage = rec.RecipeImage;
                recipe.Description = rec.Description;
                recipe.Status = rec.Status;


                this._context.Recipes.Update(recipe);
                await this._context.SaveChangesAsync();
                return recipe;
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