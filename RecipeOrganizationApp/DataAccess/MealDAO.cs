using BusinessObjects;

namespace DataAccess
{
    public class MealDAO
    {
        //Get All Meals
        public static List<Meal> GetMeals()
        {
            var listMeals = new List<Meal>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listMeals = context.Meals.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listMeals;
        }
        //Get Meal matches ID
        public static Meal GetMealsById(string id)
        {
            var meal = new Meal();
            try
            {
                using (var context = new AppDBContext())
                {
                    meal = context.Meals.Where(x => x.MealID.Equals(id)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return meal;
        }
        //Post new Meal
        public static void AddMeal(Meal meal)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    var mealAdd = new Meal
                    {
                        AccountID = meal.AccountID,
                        RecipeID= meal.RecipeID,
                        Price = meal.Price,
                        Description = meal.Description,
                        Status = meal.Status,
                    };
                    context.Meals.Add(mealAdd);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Meal
        public static void UpdateMeal(Meal meal)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var Meal = context.Meals.SingleOrDefault(x => x.MealID == meal.MealID);
                    if (Meal != null)
                    {
                        context.Entry<Meal>(meal).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Meal
        public static void DeleteMeal(Meal meal)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var Meal = context.Meals.SingleOrDefault(x => x.MealID.Equals(meal.MealID));
                    if(Meal != null)
                    {
                        context.Meals.Remove(Meal);
                        context.SaveChanges();
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}