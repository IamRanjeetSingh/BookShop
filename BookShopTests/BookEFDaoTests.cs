using BookShop.DAL;
using BookShop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookShopTests
{
	[TestClass]
	public class BookEfDaoTests
	{
		[TestMethod]
		public void Add_ValidBook_True()
		{
			IBookDao dao = new BookEfDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: false);

			Assert.IsTrue(dao.Add(book));
			Assert.IsNotNull(dao.Get(book.Id));
		}

		[TestMethod]
		public void Add_InvalidBook_True()
		{
			IBookDao dao = new BookEfDao();

			Book[] invalidBooks = ModelProvider.GetInvalidBooks();

			foreach (Book book in invalidBooks)
				Assert.IsFalse(dao.Add(book));
		}

		[TestMethod]
		public void Get_ValidId_Book()
		{
			IBookDao dao = new BookEfDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);

			Assert.IsNotNull(dao.Get(book.Id));
		}

		[TestMethod]
		public void Get_InvalidId_Book()
		{
			IBookDao dao = new BookEfDao();

			Assert.IsNull(dao.Get(-1));
		}

		[TestMethod]
		public void Update_ValidBook_True()
		{
			IBookDao dao = new BookEfDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);
			book.Description = DateTime.Now + "_description";

			Assert.IsTrue(dao.Update(book));
			Assert.AreEqual(dao.Get(book.Id), book);
		}

		[TestMethod]
		public void Update_InvalidBook_False()
		{
			IBookDao dao = new BookEfDao();

			Book[] invalidBooks = ModelProvider.GetInvalidBooks();

			foreach (Book book in invalidBooks)
				Assert.IsFalse(dao.Update(book));
		}

		[TestMethod]
		public void Remove_ValidId_True()
		{
			IBookDao dao = new BookEfDao();

			Book book = ModelProvider.GetValidBook(alreadyInsertedInDb: true);

			Assert.IsTrue(dao.Delete(book.Id));
		}

		[TestMethod]
		public void Remove_InvalidBook_False()
		{
			IBookDao dao = new BookEfDao();

			Assert.IsFalse(dao.Delete(-1));
		}
	}
}