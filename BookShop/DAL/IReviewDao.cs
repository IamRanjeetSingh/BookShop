using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.DAL
{
	public interface IReviewDao
	{
		bool Add(Review review);
		bool Update(Review review);
		bool Delete(int reviewId);
		Review GetById(int reviewId);
		IEnumerable<Review> GetByBookId(int bookId);
		IEnumerable<Review> GetByBuyerId(int buyerId);
	}
}
