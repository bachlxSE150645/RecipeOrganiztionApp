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
            dao = new ReviewDAO(dbContext);
        }

        private readonly ReviewDAO dao;

        public void AddReview(Review review) => dao.AddReview(review);
        public void UpdateReview(Review review) => dao.UpdateReview(review);
        public void DeleteReview(Review review) => dao.DeleteReview(review);
    }
}
