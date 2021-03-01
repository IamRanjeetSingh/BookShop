using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShopTests
{
	[TestClass]
	public class CartEfDaoTests
	{
		[TestMethod]
		public void Add_ValidCart_True()
		{
			CartEfDao dao = new CartEfDao();

			Cart cart = ModelProvider.GetValidCart(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(cart));
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Assert.IsNotNull(db.Carts.SingleOrDefault(c => c.BuyerId == cart.BuyerId && c.BookId == cart.BookId));
			}
		}

		[TestMethod]
		public void Add_InvalidCart_False()
		{
			ICartDao dao = new CartEfDao();

			Cart[] invalidCarts = ModelProvider.GetInvalidCarts();

			foreach (Cart cart in invalidCarts)
				Assert.IsFalse(dao.Add(cart));
		}

		[TestMethod]
		public void GetAllByBuyerId_ValidBuyerId_CartArray()
		{
			ICartDao dao = new CartEfDao();

		}
	}
}
