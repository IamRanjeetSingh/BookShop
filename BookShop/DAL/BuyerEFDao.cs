using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class BuyerEfDao : IBuyerDao
	{
		public bool Add(Buyer buyer)
		{
			if (buyer == null)  //cannot insert null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				if (db.Buyers.Any(b => b.Email == buyer.Email)) //entity with duplicate email found
					return false;

				db.Buyers.Add(buyer);
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

		public bool Delete(int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Buyer buyer = db.Buyers.SingleOrDefault(b => b.Id == buyerId);

				if (buyer == null)  //no entity found for given id
					return false;

				db.Buyers.Remove(buyer);
				db.SaveChanges();
				return true;
			}
		}

		public Buyer GetByCredentials(string email, string password)
		{
			if (email == null || password == null)  //cannot search for null credentials
				return null;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.SingleOrDefault(b => b.Email == email && b.Password == password);
			}
		}

		public Buyer GetById(int buyerId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.SingleOrDefault(b => b.Id == buyerId);
			}
		}

		public bool Update(Buyer buyer)
		{
			if (buyer == null)  //cannot update with null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Buyer trackedBuyer = db.Buyers.SingleOrDefault(b => b.Id == buyer.Id);

				if (trackedBuyer == null)   //no entity found for given id
					return false;

				if (buyer.Name != null && buyer.Name.Trim().Length != 0)
					trackedBuyer.Name = buyer.Name.Trim();
				if (buyer.Email != null && buyer.Email.Trim().Length != 0)
					trackedBuyer.Email = buyer.Email.Trim();
				if (buyer.Password != null && buyer.Password.Trim().Length != 0)
					trackedBuyer.Password = buyer.Password.Trim();

				db.SaveChanges();
				return true;
			}
		}
	}
}