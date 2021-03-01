using BookShop.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace BookShop.DAL
{
	public class BookEfDao : IBookDao
	{
		public bool Add(Book book)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int bookId)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> FindByAuthor(string author, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> FindByDistributor(string distributor, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> FindByGenre(string genre, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> FindByKeyword(string keyword, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> FindByPublisher(string publisher, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<Book> GetAll(BookOrder order, int pageNum, int pageSize)
		{
			throw new System.NotImplementedException();
		}

		public Book GetById(int bookId)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Book book)
		{
			throw new System.NotImplementedException();
		}
	}
}



/*
 public bool Add(Book book)
		{
			if (book == null)
				return false;

			using(EfDatabaseContext db = new EfDatabaseContext())
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
			using(EfDatabaseContext db = new EfDatabaseContext())
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
			using(EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Books.SingleOrDefault(b => b.Id == id);
			}
		}

		public bool Update(Book book)
		{
			if (book == null)
				return false;

			using(EfDatabaseContext db = new EfDatabaseContext())
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
 */