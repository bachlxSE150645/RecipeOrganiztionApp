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
        public IngredientRepository(AppDBContext dbContext)
        {
            dao = new IngredientDAO(dbContext);
        }

        private readonly IngredientDAO dao;

        public List<Ingredient> GetIngredients() => dao.GetIngredients();
        public Ingredient GetIngredientsById(Guid id) => dao.GetIngredientsById(id);
        public Task<Ingredient> AddIngredient(string ingredientName) => dao.AddIngredient(ingredientName);
        public void UpdateIngredient(Ingredient Ingredient) => dao.UpdateIngredient(Ingredient);
        public void DeleteIngredient(Guid Ingredient) => dao.DeleteIngredient(Ingredient);
    }
}
