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
    public class MealRepository : IMealRepository
    {
        public MealRepository(AppDBContext dbContext)
        {
            _context = MealDAO.GetInstance(dbContext);
        }

        private readonly MealDAO _context;

        public List<Meal> GetMeals() => _context.GetMeals();
        public Meal GetMealsById(string id) => _context.GetMealsById(id);
        public void AddMeal(Meal meal) => _context.AddMeal(meal);
        public void UpdateMeal(Meal meal) => _context.UpdateMeal(meal);
        public void DeleteMeal(Meal meal) => _context.DeleteMeal(meal);
    }
}
