using BusinessObjects;

namespace Repository.Interfaces
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetRecipes();
        List<Recipe> GetRecipeByName(string name);
        Recipe GetRecipesById(Guid id);
        Task<Recipe> AddRecipe(Recipe recipe);
        Task<Recipe> UpdateRecipe(Guid id, Recipe recipe);
        void DeleteRecipe(Recipe recipe);
        void UpdateContributerApprove(Recipe recipe);
    }
}
