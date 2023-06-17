using BusinessObjects;
using System.Linq.Expressions;

namespace DataAccess
{
    public class ReviewDAO
    {
        //Get All Reviews
        public static List<Review> GetRecipeDetails()
        {
            var list = new List<Review>();
            try
            {
                using (var context = new AppDBContext())
                {
                    list = context.Reviews.ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        //Get Reviews by Review ID
        public static List<Review> GetRecipeDetailsByRecipeId(string reviewId)
        {
            var listReview = new List<Review>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listReview = context.Reviews.Where(x => x.ReviewID.ToString() == reviewId).ToList();
                }
            } catch(Exception ex) {
                throw new Exception(ex.Message);
            }
            return listReview;
        }

        //Post new Review
        public static void AddReview(Review review)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    var reviewAdd = new Review
                    {
                        AccountID = review.AccountID,
                        RecipeID = review.RecipeID,
                        ReviewContent = review.ReviewContent,
                        Rating = review.Rating,
                    };
                    context.Reviews.Add(review);
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Review
        public static void UpdateReview(Review review)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var reviewCheck = context.Reviews.SingleOrDefault(x => x.ReviewID == review.ReviewID);
                    if (reviewCheck != null)
                    {
                        context.Entry<Review>(review).State =
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
        
        //Delete existing Review
        public static void DeleteReview(Review review)
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    var reviewCheck = context.Reviews.SingleOrDefault(x => x.ReviewID.Equals(review.RecipeID));
                    if (reviewCheck != null)
                    {
                        context.Reviews.Remove(reviewCheck);
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
