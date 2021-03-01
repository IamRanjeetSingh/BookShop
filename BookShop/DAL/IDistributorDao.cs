using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
	public interface IDistributorDao
	{
		bool Add(Distributor distributor);
		bool Update(Distributor distributor);
		bool Delete(int distributorId);
		Distributor GetById(int distributorId);
		Distributor GetByEmail(string email);
		bool Exists(string email, string password);
	}
}
