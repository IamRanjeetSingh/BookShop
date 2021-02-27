using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class DistributorEFDao : DistributorDao
	{
		public bool Add(Distributor distributor)
		{
			if (distributor == null)
				return false;

			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				try
				{
					db.Distributors.Add(distributor);
					db.SaveChanges();
					return true;
				}
				catch (DbEntityValidationException) { return false; }
			}
		}

		public bool Delete(int id)
		{
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Distributor distributor = db.Distributors.SingleOrDefault(d => d.Id == id);
				if (distributor == null)
					return false;

				db.Distributors.Remove(distributor);
				db.SaveChanges();
				return true;
			}
		}

		public bool DoesEmailExist(string email)
		{
			if (email == null)
				return false;

			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Distributors.FirstOrDefault(d => d.Email == email) != null;
			}
		}
		public Distributor GetByEmail(string email)
		{
			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Distributors.FirstOrDefault(d => d.Email == email);
			}
		}

		public Distributor GetById(int id)
		{
			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Distributors.SingleOrDefault(d => d.Id == id);
			}
		}


		public bool Update(Distributor distributor)
		{
			if (distributor == null)
				return false;

			using (EFDatabaseContext db = new EFDatabaseContext())
			{
				Distributor trackedBuyer = db.Distributors.SingleOrDefault(d => d.Id == distributor.Id);
				if (trackedBuyer == null)
					return false;

				trackedBuyer.Name = distributor.Name != null ? distributor.Name : trackedBuyer.Name;
				trackedBuyer.Email = distributor.Email != null ? distributor.Email : trackedBuyer.Email;
				trackedBuyer.Password = distributor.Password != null ? distributor.Password : trackedBuyer.Password;

				db.SaveChanges();
				return true;
			}
		}
	}
}