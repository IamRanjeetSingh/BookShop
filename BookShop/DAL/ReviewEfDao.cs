using BookShop.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class ReviewEfDao : IReviewDao
	{
		public bool Add(Review review)
		{
			if (review == null) //cannot insert null entity into db
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				try
				{
					db.Reviews.Add(review);
					db.SaveChanges();
					return true;
				}
				catch (DbEntityValidationException) //entity doesn't have valid properties
				{
					return false;
				}
			}
		}

		public bool Delete(int reviewId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Review review = db.Reviews.SingleOrDefault(r => r.Id == reviewId);

				if (review == null) //no entity found by the given id
					return false;

				db.Reviews.Remove(review);
				db.SaveChanges();
				return true;
			}
		}

		public IEnumerable<Review> GetByBookId(int bookId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Reviews.Where(r => r.BookId == bookId).ToArray();
			}
		}

		public IEnumerable<Review> GetByBuyerId(int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Reviews.Where(r => r.BuyerId == buyerId);
			}
		}

		public Review GetById(int reviewId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Reviews.SingleOrDefault(r => r.Id == reviewId);
			}
		}

		public bool Update(Review review)
		{
			if (review == null) //cannot update with null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Review trackedReview = db.Reviews.SingleOrDefault(r => r.Id == review.Id);

				if (trackedReview == null)  //no entity found by the given id
					return false;

				if (review.BookId > 0)
					trackedReview.BookId = review.BookId;
				if (review.BuyerId > 0)
					trackedReview.BuyerId = review.BuyerId;
				if (review.Rating != trackedReview.Rating)
					trackedReview.Rating = review.Rating;
				if (review.Comment != trackedReview.Comment)
					trackedReview.Comment = review.Comment;

				db.SaveChanges();
				return true;
			}
		}
	}
}