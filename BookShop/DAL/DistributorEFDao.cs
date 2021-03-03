using BookShop.Models;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace BookShop.DAL
{
	public class DistributorEfDao : IDistributorDao
	{
		public bool Add(Distributor distributor)
		{
			try
			{
				if (distributor == null)
					throw new NullReferenceException("Null entity cannot be inserted");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					if (db.Distributors.Any(d => d.Email == distributor.Email || d.Password == distributor.Password))
						throw new DbEntityValidationException("Duplicate Credentials found for Distributor");

					db.Distributors.Add(distributor);
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception e) when (e is DbEntityValidationException || e is NullReferenceException)
			{
				Debug.WriteLine(e);
				return false;
			}
		}

		public bool Delete(int distributorId)
		{
			try
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Distributor distributor = db.Distributors.SingleOrDefault(d => d.Id == distributorId);
					if (distributor == null)
						throw new NullReferenceException("No Distributor found for given Id");

					db.Distributors.Remove(distributor);
					db.SaveChanges();
					return true;
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return false;
			}
		}

		public Distributor GetByCredentials(string email, string password)
		{
			try
			{
				if (email == null || password == null)
					throw new NullReferenceException("Email or Password is null and cannot be used for search");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					return db.Distributors.SingleOrDefault(d => d.Email == email && d.Password == password);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
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
			try
			{
				if (distributor == null)
					throw new NullReferenceException("Null entity cannot be used for updation");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Distributor trackedDistributor = db.Distributors.SingleOrDefault(d => d.Id == distributor.Id);
					if (trackedDistributor == null)
						throw new NullReferenceException("No Distributor found for update for the given Id");

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
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return false;
			}
		}
	}
}