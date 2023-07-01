using BusinessObjects;
using BusinessObjects.MapData;

namespace Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes();
        Recipe GetRecipeByName(string name);
        Recipe GetRecipesById(Guid id);
        Task<Recipe> AddRecipe(RecipeData recipe);
        Task<Recipe> UpdateRecipe(Guid id, RecipeData recipe);
        void DeleteRecipe(Recipe recipe);
    }
}
