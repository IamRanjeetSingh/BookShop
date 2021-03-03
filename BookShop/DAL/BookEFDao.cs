using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace BookShop.DAL
{
	public class BookEfDao : IBookDao
	{
		public bool Add(Book book)
		{
			try
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					db.Books.Add(book);
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

		public bool Delete(int bookId)
		{
			try
			{
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Book book = db.Books.SingleOrDefault(b => b.Id == bookId);
					if (book == null)
						throw new NullReferenceException("No Book found for given Id");

					db.Books.Remove(book);
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

		public IEnumerable<Book> FindByAuthor(string author, int pageNum, int pageSize)
		{
			try
			{
				if (author == null)
					throw new NullReferenceException("Null Author cannot be used for search");

				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					author = author.Trim().ToLower();
					return db.Books
						.Where(b => b.Author.Trim().ToLower() == author)
						.Skip((pageNum - 1) * pageSize)
						.Take(pageSize);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Book> FindByDistributor(string book, int pageNum, int pageSize)
		{
			try
			{
				if (book == null)
					throw new NullReferenceException("Null Distributor cannot be used for search");

				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					book = book.Trim().ToLower();
					return db.Books
						.Where(b => b.Distributor.Name.Trim().ToLower() == book)
						.Skip((pageNum - 1) * pageSize)
						.Take(pageSize);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Book> FindByGenre(string genre, int pageNum, int pageSize)
		{
			try
			{
				if (genre == null)
					throw new NullReferenceException("Null Genre cannot be used for search");

				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					genre = genre.Trim().ToLower();
					return db.Books
						.Where(b => b.Genre.Trim().ToLower() == genre)
						.Skip((pageNum - 1) * pageSize)
						.Take(pageSize);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Book> FindByKeyword(string keyword, int pageNum, int pageSize)
		{
			try
			{
				if (keyword == null)
					throw new NullReferenceException("Null Keyword cannot be used for search");

				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					keyword = keyword.Trim().ToLower();
					return db.Books
						.Where(b => b.Name.Trim().ToLower().Contains(keyword) || b.Author.Trim().ToLower().Contains(keyword) || b.Publisher.Trim().ToLower().Contains(keyword))
						.Skip((pageNum - 1) * pageSize)
						.Take(pageSize);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Book> FindByPublisher(string publisher, int pageNum, int pageSize)
		{
			try
			{
				if (publisher == null)
					throw new NullReferenceException("Null Publisher cannot be used for search");

				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					publisher = publisher.Trim().ToLower();
					return db.Books
						.Where(b => b.Genre.Trim().ToLower() == publisher)
						.Skip((pageNum - 1) * pageSize)
						.Take(pageSize);
				}
			}
			catch (NullReferenceException e)
			{
				Debug.WriteLine(e);
				return null;
			}
		}

		public IEnumerable<Book> GetAll(BookOrder order, int pageNum, int pageSize)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				IEnumerable<Book> books = db.Books.Skip((pageNum - 1) * pageSize).Take(pageSize);

				switch (order)
				{
					case BookOrder.DateDesc:
						books = books.OrderByDescending(b => b.AddedAt);
						break;
					case BookOrder.Date:
						books = books.OrderBy(b => b.AddedAt);
						break;
					case BookOrder.PriceDesc:
						books = books.OrderByDescending(b => b.Price);
						break;
					case BookOrder.Price:
						books = books.OrderBy(b => b.Price);
						break;
						//case BookOrder.RatingDesc:
						//	books = books.OrderByDescending(b => b.Rating);
						//	break;
						//case BookOrder.Rating:
						//	books = books.OrderBy(b => b.Rating);
						//	break;
				}

				return books;
			}
		}

		public Book GetById(int bookId)
		{
			using (EfDatabaseContext db = new EfDatabaseContext())
			{
				return db.Books.SingleOrDefault(b => b.Id == bookId);
			}
		}

		public bool Update(Book book)
		{
			try
			{
				if (book == null)
					throw new NullReferenceException("Null entity cannot be used for updation");
				using (EfDatabaseContext db = new EfDatabaseContext())
				{
					Book trackedBook = db.Books.SingleOrDefault(b => b.Id == book.Id);
					if (trackedBook == null)
						throw new NullReferenceException("No Distributor found for update for the given Id");

					if (book.Name != null && book.Name.Trim().Length > 0)
						trackedBook.Name = book.Name.Trim();
					if (book.Description != null && book.Description.Trim().Length > 0)
						trackedBook.Description = book.Description.Trim();
					if (book.DistributorId > 0)
						trackedBook.DistributorId = book.DistributorId;
					if (book.Author != null && book.Author.Trim().Length > 0)
						trackedBook.Author = book.Author.Trim();
					if (book.Publisher != null && book.Publisher.Trim().Length > 0)
						trackedBook.Publisher = book.Publisher.Trim();
					if (book.Genre != null && book.Genre.Trim().Length > 0)
						trackedBook.Genre = book.Genre.Trim();
					if (book.Language != null && book.Language.Trim().Length > 0)
						trackedBook.Language = book.Language.Trim();
					if (book.Price > -1)
						trackedBook.Price = book.Price;
					if (book.AddedAt != null && book.AddedAt.CompareTo(DateTime.Now) <= 0)
						trackedBook.AddedAt = book.AddedAt;

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