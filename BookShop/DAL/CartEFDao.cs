using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class CartEfDao : ICartDao
	{
		public bool Add(Cart cart)
		{
			if (cart == null)   //cannot insert null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				db.Carts.Add(cart);
				try
				{
					db.SaveChanges();
					return true;
				}
				catch (DbEntityValidationException) //entity doesn't have valid properties
				{
					return false;
				}
			}
		}

		public bool Delete(int bookId, int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Cart cart = db.Carts.SingleOrDefault(c => c.BookId == bookId && c.BuyerId == buyerId);

				if (cart == null)   //no entity found for given ids
					return false;

				db.Carts.Remove(cart);
				db.SaveChanges();
				return true;
			}
		}

		public IEnumerable<Cart> GetByBuyerId(int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Carts.Where(c => c.BuyerId == buyerId).ToArray();
			}
		}

		public Cart GetById(int bookId, int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Carts.SingleOrDefault(c => c.BookId == bookId && c.BuyerId == buyerId);
			}
		}
	}
}