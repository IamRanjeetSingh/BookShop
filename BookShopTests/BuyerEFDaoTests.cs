using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShopTests
{
	[TestClass]
	public class BuyerEFDaoTests
	{
		[TestMethod]
		public void Add_ValidBuyer_True()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(buyer));
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.IsNotNull(db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Add_InvalidBuyer_False()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer[] invalidBuyers = ModelProvider.GetInvalidBuyers();

			foreach (Buyer buyer in invalidBuyers)
				Assert.IsFalse(dao.Add(buyer));
		}

		[TestMethod]
		public void Get_ValidId_Buyer()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Buyer returnedValue = dao.GetById(buyer.Id);

			Assert.IsNotNull(returnedValue);
			Assert.AreEqual(buyer, returnedValue);
		}

		[TestMethod]
		public void Get_InvalidId_Null()
		{
			BuyerDao dao = new BuyerEFDao();

			Assert.IsNull(dao.GetById(-1));
		}

		[TestMethod]
		public void Update_ValidBuyer_True()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);
			buyer.Email = buyer.Email + "_new";

			Assert.IsTrue(dao.Update(buyer));

			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.AreEqual(buyer, db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Update_InvalidBuyer_False()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer[] invalidBuyers = ModelProvider.GetInvalidBuyers();

			foreach (Buyer buyer in invalidBuyers)
				Assert.IsFalse(dao.Update(buyer));
		}

		[TestMethod]
		public void Delete_ValidId_True()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.Delete(buyer.Id));
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.IsNull(db.Buyers.SingleOrDefault(b => b.Id == buyer.Id));
			}
		}

		[TestMethod]
		public void Delete_InvalidId_False()
		{
			BuyerDao dao = new BuyerEFDao();

		}

		[TestMethod]
		public void DoesEmailExist_Exist_True()
		{
			BuyerDao dao = new BuyerEFDao();

			Buyer buyer = ModelProvider.GetValidBuyer(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.DoesEmailExist(buyer.Email));
		}

		[TestMethod]
		public void DoesEmailExist_NotExist_False()
		{
			BuyerDao dao = new BuyerEFDao();

			Assert.IsFalse(dao.DoesEmailExist("invalid_email"));
		}
	}
}
