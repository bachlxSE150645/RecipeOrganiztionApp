using BusinessObjects;

namespace DataAccess
{
    public class RecipeDAO
    {
        //Get All Recipes
        public static List<Recipe> GetRecipes()
        {
            var listRecipes = new List<Recipe>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listRecipes = context.Recipes.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listRecipes;
        }
        //Get Recipe matches RecipeID
        public static Recipe GetRecipesById(string id)
        {
            var recipe = new Recipe();
            try
            {
                using (var context = new AppDBContext())
                {
                    recipe = context.Recipes.Where(x => x.RecipeID.Equals(id)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return recipe;
        }
        //Post new Recipe
        public static void AddRecipe(Recipe recipe)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    var recipeAdd = new Recipe
                    {
                        RecipeName = recipe.RecipeName,
                        RecipeImage = recipe.RecipeImage,
                        Description = recipe.Description,
                        AccountID = recipe.AccountID,
                        Status = recipe.Status,
                        CreateDate = recipe.CreateDate,
                    };
                    context.Recipes.Add(recipeAdd);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Recipe
        public static void UpdateRecipe(Recipe recipe)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var recipeCheck = context.Recipes.SingleOrDefault(x => x.RecipeID == recipe.RecipeID);
                    if (recipeCheck != null)
                    {
                        context.Entry<Recipe>(recipe).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Recipe
        public static void DeleteRecipe(Recipe recipe)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var recipeCheck = context.Recipes.SingleOrDefault(x => x.RecipeID.Equals(recipe.RecipeID));
                    if(recipeCheck != null)
                    {
                        context.Recipes.Remove(recipeCheck);
                        context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}