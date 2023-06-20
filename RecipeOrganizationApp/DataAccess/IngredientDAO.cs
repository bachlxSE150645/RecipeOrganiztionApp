using BusinessObjects;

namespace DataAccess
{
    public class IngredientDAO
    {

        private static IngredientDAO instance;
        private readonly AppDBContext _context;

        public IngredientDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static IngredientDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new IngredientDAO(dbContext);
            }

            return instance;
        }

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
        public Ingredient GetIngredientsById(Guid id)
        {
            var Ingredient = new Ingredient();
            try
            {
                
                    Ingredient = _context.Ingredients.Where(x => x.IngredientID == id).SingleOrDefault();
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return Ingredient;
        }
        //Post new ingredient
        public async Task<Ingredient> AddIngredient(string ingredient)
        {
            try
            {
                    var Ingredient = new Ingredient
                    {
                        IngredientID = Guid.NewGuid(),
                        IngredientName = ingredient,
                        Status = true,
                    };
                    _context.Ingredients.Add(Ingredient);
                    _context.SaveChanges();
                    return Ingredient;
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