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
        public  List<Ingredient> GetIngredients()
        {
            var listIngredients = new List<Ingredient>();
            try
            {
                
                    listIngredients = _context.Ingredients.ToList();
                
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
        public void UpdateIngredient(Ingredient Ingredient)
        {
            try
            {
                
                    var ingredient = _context.Ingredients.SingleOrDefault(x => x.IngredientID == Ingredient.IngredientID);
                    if (ingredient != null)
                    {
                        _context.Entry<Ingredient>(Ingredient).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing Ingredient
        public void DeleteIngredient(Ingredient Ingredient)
        {
            try
            {
                
                    var ingredient = _context.Ingredients.SingleOrDefault(x => x.IngredientID.Equals(Ingredient.IngredientID));
                    if(ingredient != null)
                    {
                        _context.Ingredients.Remove(ingredient);
                        _context.SaveChanges();
                    }
                
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}