using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
	public interface IBuyerDao
	{
		bool Add(Buyer buyer);
		bool Update(Buyer buyer);
		bool Delete(int buyerId);
		Buyer GetById(int buyerId);
		Buyer GetByEmail(string email);
		bool Exists(string email, string password);
	}
}
