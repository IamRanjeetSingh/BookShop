using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class BuyerEFDao : BuyerDao
	{
		public bool Add(Buyer buyer)
		{
			if (buyer == null)
				return false;

			using (EFDatabaseContext db = new EFDatabaseContext())
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
			using(EFDatabaseContext db = new EFDatabaseContext())
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

			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Buyers.FirstOrDefault(b => b.Email == email) != null;
			}
		}
		public Buyer GetByEmail(string email)
		{
			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Buyers.FirstOrDefault(b => b.Email == email);
			}
		}

		public Buyer GetById(int id)
		{
			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Buyers.SingleOrDefault(b => b.Id == id);
			}
		}


		public bool Update(Buyer buyer)
		{
			if (buyer == null)
				return false;

			using(EFDatabaseContext db = new EFDatabaseContext())
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
	}
}