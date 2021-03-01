using BookShop.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace BookShop.DAL
{
	public class CartEfDao : ICartDao
	{
		public bool Add(Cart cart)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int cartId)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Cart> GetByBuyerId(int buyerId)
		{
			throw new System.NotImplementedException();
		}

		public Cart GetById(int cartId)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Cart cart)
		{
			throw new System.NotImplementedException();
		}
	}
}


/*
 public bool Add(Cart cart)
		{
			if (cart == null)
				return false;
			using (EfDatabaseContext db = new EfDatabaseContext())
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
			using (EfDatabaseContext db = new EfDatabaseContext())
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
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Cart[] carts = db.Carts.Where(c => c.BuyerId == buyerId).ToArray();
				return carts;
			}
		}
 */