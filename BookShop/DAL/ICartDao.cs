using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.DAL
{
	public interface ICartDao
	{
		bool Add(Cart cart);
		bool Delete(int bookId, int buyerId);
		Cart GetById(int bookId, int buyerId);
		IEnumerable<Cart> GetByBuyerId(int buyerId);
	}
}
