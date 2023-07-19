using BusinessObjects;
using BusinessObjects.MapData;
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

        public List<Meal> GetAllMeals() => dao.GetMeals();
        public Meal GetMealsById(Guid id) => dao.GetMealsById(id);
        public List<Meal> GetMealsByName(string mealName) => dao.GetMealsByName(mealName);
        public List<Meal> GetMealsByAccountId(Guid id) => dao.GetMealsByAccountId(id);
        public Meal AddMeal(MealData inf) => dao.AddMeal(inf);
        public Meal UpdateMeal(Guid mealID, decimal mealPrice, string mealDescription, bool saleornot) => dao.UpdateMeal(mealID, mealPrice, mealDescription,saleornot);
        public bool DeleteMeal(Guid mealID) => dao.DeleteMeal(mealID);
        public Meal GetMealByRecipeId(Guid recipeId) => dao.GetMealByRecipeId(recipeId);
    }
}
