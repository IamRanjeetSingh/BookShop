using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShopTests
{
	[TestClass]
	public class BuyerEfDaoTests
	{
		[TestMethod]
		public void Add_ValidBuyer_True()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(buyer));
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Assert.IsNotNull(db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Add_InvalidBuyer_False()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer[] invalidBuyers = ModelProvider.GetInvalidBuyers();

			foreach (Buyer buyer in invalidBuyers)
				Assert.IsFalse(dao.Add(buyer));
		}

		[TestMethod]
		public void Get_ValidId_Buyer()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Buyer returnedValue = dao.GetById(buyer.Id);

			Assert.IsNotNull(returnedValue);
			Assert.AreEqual(buyer, returnedValue);
		}

		[TestMethod]
		public void Get_InvalidId_Null()
		{
			IBuyerDao dao = new BuyerEfDao();

			Assert.IsNull(dao.GetById(-1));
		}

		[TestMethod]
		public void Update_ValidBuyer_True()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);
			buyer.Email = buyer.Email + "_new";

			Assert.IsTrue(dao.Update(buyer));

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Assert.AreEqual(buyer, db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Update_InvalidBuyer_False()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer[] invalidBuyers = ModelProvider.GetInvalidBuyers();

			foreach (Buyer buyer in invalidBuyers)
				Assert.IsFalse(dao.Update(buyer));
		}

		[TestMethod]
		public void Delete_ValidId_True()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.Delete(buyer.Id));
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Assert.IsNull(db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Delete_InvalidId_False()
		{
			IBuyerDao dao = new BuyerEfDao();

		}

		[TestMethod]
		public void DoesEmailExist_Exist_True()
		{
			IBuyerDao dao = new BuyerEfDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.DoesEmailExist(buyer.Email));
		}

		[TestMethod]
		public void DoesEmailExist_NotExist_False()
		{
			IBuyerDao dao = new BuyerEfDao();

			Assert.IsFalse(dao.DoesEmailExist("invalid_email"));
		}
	}
}
