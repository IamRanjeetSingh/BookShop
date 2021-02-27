using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.DAL
{
	public class DaoProvider
	{
		public BookDao BookDao { get; set; }
		public BuyerDao BuyerDao { get; set; }
		public DistributorDao DistributorDao { get; set; }

		public DaoProvider()
		{
			BookDao = new BookEFDao();
			BuyerDao = new BuyerEFDao();
			DistributorDao = new DistributorEFDao();
		}
	}
}