using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class DistributorEfDao : IDistributorDao
	{
		public bool Add(Distributor distributor)
		{
			if (distributor == null)    //cannot insert null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				if (db.Distributors.Any(d => d.Email == distributor.Email)) //entity with duplicate email found
					return false;

				db.Distributors.Add(distributor);

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

		public bool Delete(int distributorId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Distributor distributor = db.Distributors.SingleOrDefault(d => d.Id == distributorId);

				if (distributor == null)    //no entity found for given id
					return false;

				db.Distributors.Remove(distributor);
				db.SaveChanges();
				return true;
			}
		}

		public Distributor GetByCredentials(string email, string password)
		{
			if (email == null || password == null)  //cannot search for null credentials
				return null;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Distributors.SingleOrDefault(d => d.Email == email && d.Password == password);
			}
		}

		public Distributor GetById(int distributorId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Distributors.SingleOrDefault(d => d.Id == distributorId);
			}
		}

		public bool Update(Distributor distributor)
		{
			if (distributor == null)    //cannot update with null entity
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				Distributor trackedDistributor = db.Distributors.SingleOrDefault(d => d.Id == distributor.Id);

				if (trackedDistributor == null) //no entity found for given id
					return false;

				if (distributor.Name != null && distributor.Name.Trim().Length != 0)
					trackedDistributor.Name = distributor.Name.Trim();
				if (distributor.Email != null && distributor.Email.Trim().Length != 0)
					trackedDistributor.Email = distributor.Email.Trim();
				if (distributor.Password != null && distributor.Password.Trim().Length != 0)
					trackedDistributor.Password = distributor.Password.Trim();

				db.SaveChanges();
				return true;
			}
		}
	}
}