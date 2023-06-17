using BusinessObjects;

namespace DataAccess
{
    public class IngredientDAO
    {
        //Get All Ingredients
        public static List<Ingredient> GetIngredients()
        {
            var listIngredients = new List<Ingredient>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listIngredients = context.Ingredients.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception();
            }
            return listIngredients;
        }
        //Get Ingredient matches ID
        public static Ingredient GetIngredientsById(string id)
        {
            var Ingredient = new Ingredient();
            try
            {
                using (var context = new AppDBContext())
                {
                    Ingredient = context.Ingredients.Where(x => x.IngredientID.Equals(id)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return Ingredient;
        }
        //Post new ingredient
        public static void AddIngredient(Ingredient ingredient)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    var Ingredient = new Ingredient
                    {
                        IngredientName = ingredient.IngredientName,
                        Status = ingredient.Status,
                    };
                    context.Ingredients.Add(Ingredient);
                    context.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing Ingredient
        public static void UpdateIngredient(Ingredient Ingredient)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var ingredient = context.Ingredients.SingleOrDefault(x => x.IngredientID == Ingredient.IngredientID);
                    if (ingredient != null)
                    {
                        context.Entry<Ingredient>(Ingredient).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Ingredient
        public static void DeleteIngredient(Ingredient Ingredient)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var ingredient = context.Ingredients.SingleOrDefault(x => x.IngredientID.Equals(Ingredient.IngredientID));
                    if(ingredient != null)
                    {
                        context.Ingredients.Remove(ingredient);
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