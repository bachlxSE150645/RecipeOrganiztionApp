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
        Ingredient GetIngredientsById(string id);
        void AddIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient Ingredient);
        void DeleteIngredient(Ingredient Ingredient);
    }
}
