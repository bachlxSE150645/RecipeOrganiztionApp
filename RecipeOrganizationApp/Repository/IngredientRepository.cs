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
    public class IngredientRepository : IIngredientRepository
    {
        public List<Ingredient> GetIngredients() => IngredientDAO.GetIngredients();
        public Ingredient GetIngredientsById(string id) => IngredientDAO.GetIngredientsById(id);
        public void AddIngredient(Ingredient ingredient) => IngredientDAO.AddIngredient(ingredient);
        public void UpdateIngredient(Ingredient Ingredient) => IngredientDAO.UpdateIngredient(Ingredient);
        public void DeleteIngredient(Ingredient Ingredient) => IngredientDAO.DeleteIngredient(Ingredient);
    }
}
