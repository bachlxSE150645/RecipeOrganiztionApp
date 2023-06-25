using BusinessObjects;

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
                return _context.Meals.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Meal matches ID
        public Meal GetMealsById(string id)
        {
            try
            {
                return _context.Meals.SingleOrDefault(x => x.MealID.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Meal
        public void AddMeal(Meal meal)
        {
            try
            {
                var mealAdd = new Meal
                {
                    AccountID = meal.AccountID,
                    RecipeID = meal.RecipeID,
                    Price = meal.Price,
                    Description = meal.Description,
                    Status = meal.Status,
                };
                _context.Meals.Add(mealAdd);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Meal
        public void UpdateMeal(Meal meal)
        {
            try
            {
                var Meal = _context.Meals.SingleOrDefault(x => x.MealID == meal.MealID);
                if (Meal != null)
                {
                    _context.Entry<Meal>(meal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Meal
        public void DeleteMeal(Meal meal)
        {
            try
            {
                var Meal = _context.Meals.SingleOrDefault(x => x.MealID.Equals(meal.MealID));
                if (Meal != null)
                {
                    _context.Meals.Remove(Meal);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}