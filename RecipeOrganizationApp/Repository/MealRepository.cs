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
            dao = new MealDAO(dbContext);
        }

        private readonly MealDAO dao;

        public List<Meal> GetMeals() => dao.GetMeals();
        public Meal GetMealsById(string id) => dao.GetMealsById(id);
        public void AddMeal(Meal meal) => dao.AddMeal(meal);
        public void UpdateMeal(Meal meal) => dao.UpdateMeal(meal);
        public void DeleteMeal(Meal meal) => dao.DeleteMeal(meal);
    }
}
