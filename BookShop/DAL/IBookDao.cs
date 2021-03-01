using BookShop.Models;
using System.Collections.Generic;

namespace BookShop.DAL
{
	public interface IBookDao
	{
		bool Add(Book book);
		bool Update(Book book);
		bool Delete(int bookId);
		Book GetById(int bookId);
		IEnumerable<Book> GetAll(BookOrder order, int pageNum, int pageSize);
		IEnumerable<Book> FindByGenre(string genre, int pageNum, int pageSize);
		IEnumerable<Book> FindByAuthor(string author, int pageNum, int pageSize);
		IEnumerable<Book> FindByPublisher(string publisher, int pageNum, int pageSize);
		IEnumerable<Book> FindByDistributor(string distributor, int pageNum, int pageSize);
		IEnumerable<Book> FindByKeyword(string keyword, int pageNum, int pageSize);
	}
}
