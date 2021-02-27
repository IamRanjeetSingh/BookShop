using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
	public interface BuyerDao
	{
		bool Add(Buyer buyer);
		Buyer GetById(int id);
		Buyer GetByEmail(string email);
		bool Update(Buyer buyer);
		bool Delete(int id);
		bool DoesEmailExist(string email);
	}
}
