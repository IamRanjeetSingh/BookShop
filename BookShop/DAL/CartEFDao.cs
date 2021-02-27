using BookShop.Models;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BookShop.DAL
{
	public class CartEFDao : CartDao
	{
		public bool Add(Cart cart)
		{
			if (cart == null)
				return false;
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				try
				{
					db.Carts.Add(cart);
					db.SaveChanges();
					return true;
				}
				catch (DbUpdateException) //DbUpdateException is thrown when Foreign key constraint is violated for Cart entity
				{ return false; }
			}
		}

		public bool Delete(int buyerId, int bookId)
		{
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Cart cart = db.Carts.SingleOrDefault(c => c.BuyerId == buyerId && c.BookId == bookId);
				if (cart == null)
					return false;

				db.Carts.Remove(cart);
				db.SaveChanges();
				return true;
			}
		}

		public Cart[] GetAllByBuyerId(int buyerId)
		{
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Cart[] carts = db.Carts.Where(c => c.BuyerId == buyerId).ToArray();
				return carts;
			}
		}
	}
}