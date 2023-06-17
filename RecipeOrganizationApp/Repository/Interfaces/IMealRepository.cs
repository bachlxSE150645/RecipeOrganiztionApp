using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IMealRepository
    {
        List<Meal> GetMeals();
        Meal GetMealsById(string id);
        void AddMeal(Meal meal);
        void UpdateMeal(Meal meal);
        void DeleteMeal(Meal meal);
    }
}
