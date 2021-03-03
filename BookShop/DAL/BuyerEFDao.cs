using BookShop.Models;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace BookShop.DAL
{
	public class BuyerEfDao : IBuyerDao
	{
		public bool Add(Buyer buyer)
		{
			try
			{
				if (buyer == null)
					throw new NullReferenceException("Null entity cannot be inserted");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					if (db.Buyers.Any(b => b.Email == buyer.Email || b.Password == buyer.Password))
						throw new DbEntityValidationException("Duplicate Credentials found for Buyer");

					db.Buyers.Add(buyer);
					db.SaveChanges();
					return true;
				}
			}
			catch(Exception e) when (e is DbEntityValidationException || e is NullReferenceException)
			{
				Debug.WriteLine(e);
				return false;
			}
		}

		public bool Delete(int buyerId)
		{
			try
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Buyer buyer = db.Buyers.SingleOrDefault(b => b.Id == buyerId);
					if (buyer == null)
						throw new NullReferenceException("No Buyer found for given Id");
					
					db.Buyers.Remove(buyer);
					db.SaveChanges();
					return true;
				}
			}
			catch(NullReferenceException e)
			{
				Debug.WriteLine(e);
				return false;
			}
		}

		public Buyer GetByCredentials(string email, string password)
		{
			try
			{
				if (email == null || password == null)
					throw new NullReferenceException("Email or Password is null and cannot be used for search");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					return db.Buyers.SingleOrDefault(b => b.Email == email && b.Password == password);
				}
			}
			catch(NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public Buyer GetById(int buyerId)
		{
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Buyers.SingleOrDefault(b => b.Id == buyerId);
			}
		}

		public bool Update(Buyer buyer)
		{
			try
			{
				if (buyer == null)
					throw new NullReferenceException("Null entity cannot be used for updation");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Buyer trackedBuyer = db.Buyers.SingleOrDefault(b => b.Id == buyer.Id);
					if (trackedBuyer == null)
						throw new NullReferenceException("No Buyer found for update for the given Id");

					if(buyer.Name != null && buyer.Name.Trim().Length != 0)
						trackedBuyer.Name = buyer.Name.Trim();
					if(buyer.Email != null && buyer.Email.Trim().Length != 0)
						trackedBuyer.Email = buyer.Email.Trim();
					if(buyer.Password != null && buyer.Password.Trim().Length != 0)
						trackedBuyer.Password = buyer.Password.Trim();

					db.SaveChanges();
					return true;
				}
			}
			catch(NullReferenceException e)
			{
				Debug.WriteLine(e);
				return false;
			}
		}
	}
}