using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IReviewRepository
    {
        List<Review> GetRecipeDetails();
        List<Review> GetRecipeDetailsByRecipeId(string reviewId);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
    }
}
