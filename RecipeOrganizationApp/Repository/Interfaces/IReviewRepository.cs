using BusinessObjects;
using BusinessObjects.MapData;
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
        List<Review> GetAllReview();
        Review GetReviewById(Guid reviewID);
        List<Review> GetReviewByRecipe(Guid recipe);

        Review AddReview(ReviewData review);
        Review UpdateReview(Guid ReviewId, string? newContent,float rating);

        bool DeleteReview(Guid reviewID);
    }
}
