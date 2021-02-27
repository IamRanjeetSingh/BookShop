using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookShopTests
{
	[TestClass]
	public class BookEFDaoTests
	{
		[TestMethod]
		public void Add_ValidBook_True()
		{
			BookDao dao = new BookEFDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(book));
			Assert.IsNotNull(dao.Get(book.Id));
		}

		[TestMethod]
		public void Add_InvalidBook_True()
		{
			BookDao dao = new BookEFDao();

			Book[] invalidBooks = ModelProvider.GetInvalidBooks();

			foreach (Book book in invalidBooks)
				Assert.IsFalse(dao.Add(book));
		}

		[TestMethod]
		public void Get_ValidId_Book()
		{
			BookDao dao = new BookEFDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);

			Assert.IsNotNull(dao.Get(book.Id));
		}

		[TestMethod]
		public void Get_InvalidId_Book()
		{
			BookDao dao = new BookEFDao();

			Assert.IsNull(dao.Get(-1));
		}

		[TestMethod]
		public void Update_ValidBook_True()
		{
			BookDao dao = new BookEFDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);
			book.Description = DateTime.Now + "_description";

			Assert.IsTrue(dao.Update(book));
			Assert.AreEqual(dao.Get(book.Id), book);
		}

		[TestMethod]
		public void Update_InvalidBook_False()
		{
			BookDao dao = new BookEFDao();

			Book[] invalidBooks = ModelProvider.GetInvalidBooks();

			foreach (Book book in invalidBooks)
				Assert.IsFalse(dao.Update(book));
		}

		[TestMethod]
		public void Remove_ValidId_True()
		{
			BookDao dao = new BookEFDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.Delete(book.Id));
		}

		[TestMethod]
		public void Remove_InvalidBook_False()
		{
			BookDao dao = new BookEFDao();

			Assert.IsFalse(dao.Delete(-1));
		}
	}
}