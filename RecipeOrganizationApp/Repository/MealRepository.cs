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
        public List<Meal> GetMeals() => MealDAO.GetMeals();
        public Meal GetMealsById(string id) => MealDAO.GetMealsById(id);
        public void AddMeal(Meal meal) => MealDAO.AddMeal(meal);
        public void UpdateMeal(Meal meal) => MealDAO.UpdateMeal(meal);
        public void DeleteMeal(Meal meal) => MealDAO.DeleteMeal(meal);
    }
}
