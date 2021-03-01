using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class BuyerEfDao : IBuyerDao
	{
		public bool Add(Buyer buyer)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int buyerId)
		{
			throw new System.NotImplementedException();
		}

		public bool Exists(string email, string password)
		{
			throw new System.NotImplementedException();
		}

		public Buyer GetByEmail(string email)
		{
			throw new System.NotImplementedException();
		}

		public Buyer GetById(int buyerId)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Buyer buyer)
		{
			throw new System.NotImplementedException();
		}
	}
}


/*
 public bool Add(Buyer buyer)
		{
			if (buyer == null)
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				try
				{
					db.Buyers.Add(buyer);
					db.SaveChanges();
					return true;
				}
				catch (DbEntityValidationException) { return false; }
			}
		}

		public bool Delete(int id)
		{
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				Buyer buyer = db.Buyers.SingleOrDefault(b => b.Id == id);
				if (buyer == null)
					return false;

				db.Buyers.Remove(buyer);
				db.SaveChanges();
				return true;
			}
		}

		public bool DoesEmailExist(string email)
		{
			if (email == null)
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.FirstOrDefault(b => b.Email == email) != null;
			}
		}
		public Buyer GetByEmail(string email)
		{
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.FirstOrDefault(b => b.Email == email);
			}
		}

		public Buyer GetById(int id)
		{
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.SingleOrDefault(b => b.Id == id);
			}
		}


		public bool Update(Buyer buyer)
		{
			if (buyer == null)
				return false;

			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				Buyer trackedBuyer = db.Buyers.SingleOrDefault(b => b.Id == buyer.Id);
				if (trackedBuyer == null)
					return false;

				trackedBuyer.Name = buyer.Name != null ? buyer.Name : trackedBuyer.Name;
				trackedBuyer.Email = buyer.Email != null ? buyer.Email : trackedBuyer.Email;
				trackedBuyer.Password = buyer.Password != null ? buyer.Password : trackedBuyer.Password;

				db.SaveChanges();
				return true;
			}	
		}
 */