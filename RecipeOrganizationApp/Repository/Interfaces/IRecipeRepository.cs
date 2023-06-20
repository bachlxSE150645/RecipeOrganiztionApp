using BusinessObjects;
using BusinessObjects.MapData;

namespace Repository.Interfaces
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipesById(string id);
        Task<Recipe> AddRecipe(RecipeData recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);
    }
}
