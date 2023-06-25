using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using BusinessObjects.MapData;

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
                return _context.Reviews.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get Reviews by Review ID
        public List<Review> GetReviewsByReviewId(string reviewId)
        {
            try
            {
                return _context.Reviews.Where(x => x.ReviewID == Guid.Parse(reviewId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Review
        public void AddReview(Review review)
        {
            try
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
            catch (Exception ex)
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
                    _context.Entry(reviewCheck).CurrentValues.SetValues(review);
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
                var reviewCheck = _context.Reviews.SingleOrDefault(x => x.ReviewID == review.ReviewID);
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