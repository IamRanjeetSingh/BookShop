using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.DAL
{
	public class DaoContainer
	{
		public IBookDao BookDao { get; set; }
		public IBuyerDao BuyerDao { get; set; }
		public IDistributorDao DistributorDao { get; set; }
		public ICartDao CartDao { get; set; }

		public DaoContainer(BookEfDao bookDao, BuyerEfDao buyerDao, DistributorEfDao distributorDao, CartEfDao cartDao)
		{
			BookDao = bookDao;
			BuyerDao = buyerDao;
			DistributorDao = distributorDao;
			CartDao = cartDao;
		}
	}
}