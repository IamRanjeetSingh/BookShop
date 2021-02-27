using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BookShopTests
{
	[TestClass]
	public class DistributorEFDaoTests
	{
		[TestMethod]
		public void Add_ValidBuyer_True()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor distributor = ModelProvider.GetValidDistributor(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(distributor));
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.IsNotNull(db.Distributors.SingleOrDefault(d => d.Id == distributor.Id));
			}
		}

		[TestMethod]
		public void Add_InvalidBuyer_False()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor[] invalidBuyers = ModelProvider.GetInvalidDistributors();

			foreach (Distributor distributor in invalidBuyers)
				Assert.IsFalse(dao.Add(distributor));
		}

		[TestMethod]
		public void Get_ValidId_Buyer()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor distributor = ModelProvider.GetValidDistributor(alreadyInsertedInDb: true);

			Distributor returnedValue = dao.GetById(distributor.Id);

			Assert.IsNotNull(returnedValue);
			Assert.AreEqual(distributor, returnedValue);
		}

		[TestMethod]
		public void Get_InvalidId_Null()
		{
			DistributorDao dao = new DistributorEFDao();

			Assert.IsNull(dao.GetById(-1));
		}

		[TestMethod]
		public void Update_ValidBuyer_True()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor distributor = ModelProvider.GetValidDistributor(alreadyInsertedInDb: true);
			distributor.Email = distributor.Email + "_new";

			Assert.IsTrue(dao.Update(distributor));

			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.AreEqual(distributor, db.Distributors.SingleOrDefault(d => d.Id == distributor.Id));
			}
		}

		[TestMethod]
		public void Update_InvalidBuyer_False()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor[] invalidBuyers = ModelProvider.GetInvalidDistributors();

			foreach (Distributor distributor in invalidBuyers)
				Assert.IsFalse(dao.Update(distributor));
		}

		[TestMethod]
		public void Delete_ValidId_True()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor distributor = ModelProvider.GetValidDistributor(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.Delete(distributor.Id));
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Assert.IsNull(db.Distributors.SingleOrDefault(d => d.Id == distributor.Id));
			}
		}

		[TestMethod]
		public void Delete_InvalidId_False()
		{
			DistributorDao dao = new DistributorEFDao();
		}

		[TestMethod]
		public void DoesEmailExist_Exist_True()
		{
			DistributorDao dao = new DistributorEFDao();

			Distributor distributor = ModelProvider.GetValidDistributor(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.DoesEmailExist(distributor.Email));
		}

		[TestMethod]
		public void DoesEmailExist_NotExist_False()
		{
			DistributorDao dao = new DistributorEFDao();
			Assert.IsFalse(dao.DoesEmailExist("invalid_email"));
		}
	}
}