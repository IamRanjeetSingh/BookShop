using BookShop.Models;

namespace BookShop.DAL
{
	public interface CartDao
	{
		bool Add(Cart cart);
		Cart[] GetAllByBuyerId(int buyerId);
		bool Delete(int buyerId, int bookId);
	}
}
