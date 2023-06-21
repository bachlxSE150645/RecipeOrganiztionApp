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
        public ReviewRepository(AppDBContext dbContext)
        {
            _context = ReviewDAO.GetInstance(dbContext);
        }

        private readonly ReviewDAO _context;

        public List<Review> GetRecipeDetails() => _context.GetRecipeDetails();
        public List<Review> GetRecipeDetailsByRecipeId(string reviewId) => _context.GetRecipeDetailsByRecipeId(reviewId);
        public void AddReview(Review review) => _context.AddReview(review);
        public void UpdateReview(Review review) => _context.UpdateReview(review);
        public void DeleteReview(Review review) => _context.DeleteReview(review);
    }
}
