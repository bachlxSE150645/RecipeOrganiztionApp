using BusinessObjects;

namespace DataAccess
{
    public class MealDAO
    {
        private static MealDAO instance;
        private readonly AppDBContext _context;

        public MealDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static MealDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new MealDAO(dbContext);
            }

            return instance;
        }

        //Get All Meals
        public List<Meal> GetMeals()
        {
            var listMeals = new List<Meal>();
            try
            {
                
                    listMeals = _context.Meals.ToList();
                
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listMeals;
        }
        //Get Meal matches ID
        public Meal GetMealsById(string id)
        {
            var meal = new Meal();
            try
            {
                
                    meal = _context.Meals.Where(x => x.MealID.Equals(id)).SingleOrDefault();
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return meal;
        }
        //Post new Meal
        public void AddMeal(Meal meal)
        {
            try
            {
                
                    var mealAdd = new Meal
                    {
                        AccountID = meal.AccountID,
                        RecipeID= meal.RecipeID,
                        Price = meal.Price,
                        Description = meal.Description,
                        Status = meal.Status,
                    };
                    _context.Meals.Add(mealAdd);
                    _context.SaveChanges();
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Meal
        public  void UpdateMeal(Meal meal)
        {
            try
            {
                
                    var Meal = _context.Meals.SingleOrDefault(x => x.MealID == meal.MealID);
                    if (Meal != null)
                    {
                        _context.Entry<Meal>(meal).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                
            } catch(Exception ex)
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
                    if(Meal != null)
                    {
                        _context.Meals.Remove(Meal);
                        _context.SaveChanges();
                    }
                
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}