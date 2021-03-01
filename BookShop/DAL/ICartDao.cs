using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.DAL
{
	public interface ICartDao
	{
		bool Add(Cart cart);
		bool Update(Cart cart);
		bool Delete(int cartId);
		Cart GetById(int cartId);
		IEnumerable<Cart> GetByBuyerId(int buyerId);
	}
}
