using BookShop.Models;

namespace BookShop.DAL
{
	public interface BookDao
	{
		bool Add(Book book);
		Book Get(int id);
		bool Update(Book book);
		bool Delete(int id);
	}
}
