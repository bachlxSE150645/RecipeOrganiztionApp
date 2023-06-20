using BusinessObjects;
using BusinessObjects.MapData;
using System.Linq.Expressions;

namespace DataAccess
{
    public class RecipeDetailDAO
    {
        private static RecipeDetailDAO instance;
        private readonly AppDBContext _context;
        //private readonly IMapper _mapper;

        public RecipeDetailDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static RecipeDetailDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new RecipeDetailDAO(dbContext);
            }

            return instance;
        }


        //Get All Recipe Details
        public static List<RecipeDetail> GetRecipeDetails()
        {
            var list = new List<RecipeDetail>();
            try
            {
                using (var context = new AppDBContext())
                {
                    list = context.RecipeDetails.ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Get Recipe Details by Recipe ID
        public static List<RecipeDetail> GetRecipeDetailsByRecipeId(string recipeId)
        {
            var listRecipeDetail = new List<RecipeDetail>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listRecipeDetail = context.RecipeDetails.Where(x=> x.RecipeID.ToString() == recipeId).ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return listRecipeDetail;
        }

        //Get Recipe Details by Ingredient ID
        public static List<RecipeDetail> GetRecipeDetailsByIngredientId(string ingredientId)
        {
            var listRecipeDetail = new List<RecipeDetail>();
            try
            {
                using (var context = new AppDBContext())
                {
                    listRecipeDetail = context.RecipeDetails.Where(x => x.IngredientID.ToString() == ingredientId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRecipeDetail;
        }

        //Get Recipe Detail by Recipe ID and Ingredient ID
        public static RecipeDetail GetRecipeDetailsByRecIdAndIngId(string recId, string IngId)
        {
            var recipeDetail = new RecipeDetail();
            try
            {
                using(var context = new AppDBContext())
                {
                    recipeDetail = context.RecipeDetails.SingleOrDefault(x => x.RecipeID.ToString() == recId && x.IngredientID.ToString() == IngId);
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recipeDetail;
        }

        //Post new Recipe Detail
        public async Task<RecipeDetail> AddRecipeDetail(RecipeDetailData inf)
        {
            try
            {
                var recipeDetail = new RecipeDetail
                {
                    IngredientID = inf.IngredientID,
                    RecipeID = inf.RecipeID,
                    Quantity = inf.Quantity,
                    Unit = inf.Unit
                };
                _context.RecipeDetails.Add(recipeDetail);
                _context.SaveChanges();
                return recipeDetail;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Recipe by Recipe ID and Ingredient ID
        public static void UpdateRecipeDetail(RecipeDetail recipeDetail)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var recipeDetailCheck = context.RecipeDetails.SingleOrDefault(x => x.RecipeID == recipeDetail.RecipeID && x.IngredientID == recipeDetail.IngredientID);
                    if (recipeDetailCheck != null)
                    {
                        context.Entry<RecipeDetail>(recipeDetail).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        //Delete existing Recipe Detail
        public static void DeleteRecipeDetail(RecipeDetail recipeDetail)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var recipeDetailCheck = context.RecipeDetails.SingleOrDefault(x => x.RecipeID.Equals(recipeDetail.RecipeID) && x.IngredientID.Equals(recipeDetail.IngredientID));
                    if (recipeDetailCheck != null)
                    {
                        context.RecipeDetails.Remove(recipeDetailCheck);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
