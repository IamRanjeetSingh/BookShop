using BookShop.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class DistributorEfDao : IDistributorDao
	{
		public bool Add(Distributor distributor)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int distributorId)
		{
			throw new System.NotImplementedException();
		}

		public bool Exists(string email, string password)
		{
			throw new System.NotImplementedException();
		}

		public Distributor GetByEmail(string email)
		{
			throw new System.NotImplementedException();
		}

		public Distributor GetById(int distributorId)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Distributor distributor)
		{
			throw new System.NotImplementedException();
		}
	}
}

/*
 public bool Add(Distributor distributor)
		{
			if (distributor == null)
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
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
			using (EfDatabaseContext db = new EfDatabaseContext())
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

			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Distributors.FirstOrDefault(d => d.Email == email) != null;
			}
		}
		public Distributor GetByEmail(string email)
		{
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Distributors.FirstOrDefault(d => d.Email == email);
			}
		}

		public Distributor GetById(int id)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Distributors.SingleOrDefault(d => d.Id == id);
			}
		}


		public bool Update(Distributor distributor)
		{
			if (distributor == null)
				return false;

			using (EfDatabaseContext db = new EfDatabaseContext())
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
 */