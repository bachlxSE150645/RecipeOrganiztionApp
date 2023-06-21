using BusinessObjects;
using System.Linq.Expressions;

namespace DataAccess
{
    public class ReviewDAO
    {
        private static ReviewDAO instance;
        private readonly AppDBContext _context;

        public ReviewDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static ReviewDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new ReviewDAO(dbContext);
            }

            return instance;
        }

        //Get All Reviews
        public List<Review> GetRecipeDetails()
        {
            var list = new List<Review>();
            try
            {
                
                    list = _context.Reviews.ToList();
                
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Get Reviews by Review ID
        public List<Review> GetRecipeDetailsByRecipeId(string reviewId)
        {
            var listReview = new List<Review>();
            try
            {
                
                    listReview = _context.Reviews.Where(x => x.ReviewID.ToString() == reviewId).ToList();
                
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return listReview;
        }

        //Post new Review
        public  void AddReview(Review review)
        {
            try
            {
                
                    var reviewAdd = new Review
                    {
                        AccountID = review.AccountID,
                        RecipeID = review.RecipeID,
                        ReviewContent = review.ReviewContent,
                        Rating = review.Rating,
                    };
                    _context.Reviews.Add(review);
                    _context.SaveChanges();
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Review
        public void UpdateReview(Review review)
        {
            try
            {
                
                    var reviewCheck = _context.Reviews.SingleOrDefault(x => x.ReviewID == review.ReviewID);
                    if (reviewCheck != null)
                    {
                            _context.Entry<Review>(review).State =
                            Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        //Delete existing Review
        public void DeleteReview(Review review)
        {
            try
            {
                
                    var reviewCheck = _context.Reviews.SingleOrDefault(x => x.ReviewID.Equals(review.RecipeID));
                    if (reviewCheck != null)
                    {
                        _context.Reviews.Remove(reviewCheck);
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
