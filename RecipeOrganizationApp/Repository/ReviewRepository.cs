using BusinessObjects;
using BusinessObjects.MapData;
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
            dao = new ReviewDAO(dbContext);
        }

        private readonly ReviewDAO dao;

        public List<Review> GetAllReview() => dao.GetReviews();
        public Review GetReviewById(Guid reviewID) => dao.GetReviewsByReviewId(reviewID);
        public List<Review> GetReviewByRecipe(Guid recipe) => dao.GetReviewsByRecipeId(recipe);

        public Review AddReview(ReviewData review) => dao.AddReview(review);
        public Review UpdateReview(Guid ReviewId, string? newContent, float rating) 
            => dao.UpdateReview(ReviewId, newContent, rating);
        public bool DeleteReview(Guid reviewID) => dao.DeleteReview(reviewID);
    }
}
