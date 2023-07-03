using BusinessObjects;
using BusinessObjects.MapData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMealRepository
    {
        List<Meal> GetAllMeals();
        Meal GetMealsById(Guid id);

        Meal AddMeal(MealData inf);
        Meal UpdateMeal(Guid mealID, decimal mealPrice, string mealDescription);

        bool DeleteMeal(Guid mealID);
    }
}
