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

        public Meal AddMeal(MealData inf) => dao.AddMeal(inf);
        public Meal UpdateMeal(Guid mealID, decimal mealPrice, string mealDescription) => dao.UpdateMeal(mealID, mealPrice, mealDescription);
        public bool DeleteMeal(Guid mealID) => dao.DeleteMeal(mealID);
    }
}
