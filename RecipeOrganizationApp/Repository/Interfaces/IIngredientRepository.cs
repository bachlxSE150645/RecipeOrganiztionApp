using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IIngredientRepository
    {
        List<Ingredient> GetIngredients();
        Ingredient GetIngredientsById(Guid id);
        Task<Ingredient> AddIngredient(string ingredientName);
        void UpdateIngredient(Ingredient Ingredient);
        void DeleteIngredient(Ingredient Ingredient);
    }
}
