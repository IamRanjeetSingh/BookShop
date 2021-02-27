using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShopTests
{
	[TestClass]
	public class CartEFDaoTests
	{
		[TestMethod]
		public void Add_ValidCart_True()
		{
			CartEFDao dao = new CartEFDao();

			Cart cart = ModelProvider.GetValidCart(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(cart));
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.IsNotNull(db.Carts.SingleOrDefault(c => c.BuyerId == cart.BuyerId && c.BookId == cart.BookId));
			}
		}

		[TestMethod]
		public void Add_InvalidCart_False()
		{
			CartDao dao = new CartEFDao();

			Cart[] invalidCarts = ModelProvider.GetInvalidCarts();

			foreach (Cart cart in invalidCarts)
				Assert.IsFalse(dao.Add(cart));
		}

		[TestMethod]
		public void GetAllByBuyerId_ValidBuyerId_CartArray()
		{
			CartDao dao = new CartEFDao();

		}
	}
}
