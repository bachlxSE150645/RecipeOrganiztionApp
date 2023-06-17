using BusinessObjects;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReviewRepository : IReviewRepository
    {
        public List<Review> GetRecipeDetails() => ReviewDAO.GetRecipeDetails();
        public List<Review> GetRecipeDetailsByRecipeId(string reviewId) => ReviewDAO.GetRecipeDetailsByRecipeId(reviewId);
        public void AddReview(Review review) => ReviewDAO.AddReview(review);
        public void UpdateReview(Review review) => ReviewDAO.UpdateReview(review);
        public void DeleteReview(Review review) => ReviewDAO.DeleteReview(review);
    }
}
