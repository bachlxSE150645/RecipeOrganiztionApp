using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace DataAccess
{
    public class MealDAO
    {
        private readonly AppDBContext _context;

        public MealDAO(AppDBContext context)
        {
            this._context = context;
        }

        //Get All Meals
        public List<Meal> GetMeals()
        {
            try
            {
                return this._context.Meals
                    .Include(c => c.Account)
                    .Include(c => c.Recipe)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Meal matches ID
        public Meal GetMealsById(Guid id)
        {
            var meal = new Meal();
            try
            {

                meal = _context.Meals
                    .Include(c => c.Account)
                    .Include(c => c.Recipe)
                    .Where(x => x.MealID.Equals(id)).SingleOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return meal;
        }

        //Post new Meal
        public Meal AddMeal(MealData meal)
        {
            try
            {
                var mealAdd = new Meal
                {
                    MealID = Guid.NewGuid(),
                    AccountID = meal.AccountID,
                    RecipeID = meal.RecipeID,
                    Price = meal.Price,
                    Description = meal.Description,
                    Status = "On Sale",
                    Account = _context.Accounts.SingleOrDefault(c => c.AccountID == meal.AccountID),
                    Recipe = _context.Recipes.SingleOrDefault(c => c.RecipeID == meal.RecipeID)
                };
                _context.Meals.Add(mealAdd);
                _context.SaveChanges();
                return mealAdd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Meal
        public Meal UpdateMeal(Guid mealID, decimal mealPrice, string mealDescription)
        {
            try
            {
                var Meal = _context.Meals.SingleOrDefault(x => x.MealID == mealID);
                if (Meal != null)
                {
                    Meal.Price = mealPrice;
                    Meal.Description = mealDescription;

                    _context.Entry<Meal>(Meal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return Meal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Meal
        public bool DeleteMeal(Guid mealID)
        {
            try
            {
                bool check = false;
                var Meal = _context.Meals.SingleOrDefault(x => x.MealID.Equals(mealID));
                if (Meal != null)
                {
                    _context.Meals.Remove(Meal);
                    _context.SaveChanges();
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}