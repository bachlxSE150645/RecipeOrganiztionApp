using BusinessObjects;

namespace DataAccess
{
    public class IngredientDAO
    {
        private readonly AppDBContext _context;

        public IngredientDAO(AppDBContext context)
        {
            this._context = context;
        }

        //Get All Ingredients
        public List<Ingredient> GetIngredients()
        {
            
            try
            {
                List<Ingredient> ingredientList = new List<Ingredient>();
                ingredientList = this._context.Ingredients
                   .Where(x => x.Status.Equals(true)).ToList();
                return ingredientList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Ingredient> GetIngredientsForMode()
        {
            try
            {
                List<Ingredient> ingredientList = new List<Ingredient>();
                ingredientList = this._context.Ingredients.ToList();
                return ingredientList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Ingredient matches ID
        public Ingredient GetIngredientsById(Guid id)
        {
            try
            {
                return _context.Ingredients.SingleOrDefault(x => x.IngredientID == id && x.Status == true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new ingredient
        public async Task<Ingredient> AddIngredient(string ingredient)
        {
            try
            {
                var newIngredient = new Ingredient
                {
                    IngredientID = Guid.NewGuid(),
                    IngredientName = ingredient,
                    Status = true,
                };
                _context.Ingredients.Add(newIngredient);
                await _context.SaveChangesAsync();
                return newIngredient;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Ingredient
        public void UpdateIngredient(Ingredient ingredient)
        {
            try
            {
                var existingIngredient = _context.Ingredients.SingleOrDefault(x => x.IngredientID == ingredient.IngredientID);
                if (existingIngredient != null)
                {
                    _context.Entry<Ingredient>(ingredient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Ingredient
        public void DeleteIngredient(Guid ingredient)
        {
            try
            {
                var existingIngredient = _context.Ingredients.SingleOrDefault(x => x.IngredientID.Equals(ingredient));
                if (existingIngredient != null)
                {
                    existingIngredient.Status = false;
                    _context.Ingredients.Update(existingIngredient);
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