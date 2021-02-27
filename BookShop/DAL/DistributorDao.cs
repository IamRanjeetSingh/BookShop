using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
	public interface DistributorDao
	{
		bool Add(Distributor distributor);
		Distributor GetById(int id);
		Distributor GetByEmail(string email);
		bool Update(Distributor distributor);
		bool Delete(int id);
		bool DoesEmailExist(string email);
	}
}
