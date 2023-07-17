using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BusinessObjects;
using BusinessObjects.MapData;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ReviewDAO
    {
        private readonly AppDBContext _context;

        public ReviewDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get All Reviews
        public List<Review> GetReviews()
        {
            try
            {
                return this._context.Reviews
                    .Include(x => x.Account)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Reviews by Review ID
        public Review GetReviewsByReviewId(Guid reviewId)
        {
            try
            {
                return _context.Reviews.Where(x => x.ReviewID == reviewId)
                    .Include(x => x.Account)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //get all review of one recipe
        public List<Review> GetReviewsByRecipeId(Guid recipeId)
        {
            try
            {
                return _context.Reviews.Where(x => x.Recipe.RecipeID == recipeId)
                    .Include(x => x.Account)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Review
        public Review AddReview(ReviewData review)
        {
            try
            {
                var newReview = new Review
                {
                    ReviewID = Guid.NewGuid(),
                    AccountID = review.AccountID,
                    RecipeID = review.RecipeID,
                    ReviewContent = review.ReviewContent,
                    Rating = review.Rating,
                    Account = _context.Accounts.Where(c => c.AccountID == review.AccountID).FirstOrDefault(),
                    //Recipe = _context.Recipes.Where(c => c.RecipeID == review.RecipeID).FirstOrDefault()

                };
                _context.Reviews.Add(newReview);
                _context.SaveChanges();
                return newReview;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing Review
        public Review UpdateReview(Guid ReviewId, string? newContent, float rating)
        {
            try
            {
                var reviewCheck = _context.Reviews.SingleOrDefault(x => x.ReviewID == ReviewId);
                if (reviewCheck != null)
                {
                    if(rating != 0)
                    reviewCheck.Rating = rating;
                    if(newContent.Count() > 0)
                    reviewCheck.ReviewContent = newContent;

                    _context.Entry<Review>(reviewCheck).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return reviewCheck;
                }
                return reviewCheck;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing Review
        public bool DeleteReview(Guid reviewID)
        {
            try
            {
                var reviewCheck = _context.Reviews.SingleOrDefault(x => x.ReviewID == reviewID);
                if (reviewCheck != null)
                {
                    _context.Reviews.Remove(reviewCheck);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}