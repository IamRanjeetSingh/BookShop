using BookShop.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class BookEFDao : BookDao
	{
		public bool Add(Book book)
		{
			if (book == null)
				return false;

			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				try
				{
					db.Books.Add(book);
					db.SaveChanges();
					return true;
				}
				catch(DbEntityValidationException) { return false; }
				catch(DbUpdateException) { return false; }
			}
		}

		public bool Delete(int id)
		{
			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				Book book = db.Books.SingleOrDefault(b => b.Id == id);
				if (book == null)
					return false;

				db.Books.Remove(book);
				db.SaveChanges();
				return true;
			}
		}

		public Book Get(int id)
		{
			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				return db.Books.SingleOrDefault(b => b.Id == id);
			}
		}

		public bool Update(Book book)
		{
			if (book == null)
				return false;

			using(EFDatabaseContext db = new EFDatabaseContext())
			{
				Book trackedBook = db.Books.SingleOrDefault(b => b.Id == book.Id);

				if (trackedBook == null)
					return false;

				trackedBook.Name = book.Name != null ? book.Name : trackedBook.Name;
				trackedBook.Description = book.Description != null ? book.Description : trackedBook.Description;
				trackedBook.Author = book.Author != null ? book.Author : trackedBook.Author;
				trackedBook.Publisher = book.Publisher != null ? book.Publisher : trackedBook.Publisher;
				trackedBook.Language = book.Language != null ? book.Language : trackedBook.Language;
				trackedBook.Genre = book.Genre != null ? book.Genre : trackedBook.Genre;
				trackedBook.Price = book.Price >= 0 ? book.Price : trackedBook.Price;
				trackedBook.DistributorId = book.DistributorId > 0 ? book.DistributorId : trackedBook.DistributorId;

				db.SaveChanges();
				return true;
			}
		}
	}
}