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
            _context = IngredientDAO.GetInstance(dbContext);
        }

        private readonly IngredientDAO _context;

        public List<Ingredient> GetIngredients() => _context.GetIngredients();
        public Ingredient GetIngredientsById(Guid id) => _context.GetIngredientsById(id);
        public Task<Ingredient> AddIngredient(string ingredientName) => _context.AddIngredient(ingredientName);
        public void UpdateIngredient(Ingredient Ingredient) => _context.UpdateIngredient(Ingredient);
        public void DeleteIngredient(Ingredient Ingredient) => _context.DeleteIngredient(Ingredient);
    }
}
