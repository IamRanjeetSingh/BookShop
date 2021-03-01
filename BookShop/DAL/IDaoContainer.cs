using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
	public interface IDaoContainer
	{
		IBookDao BookDao { get; set; }
		IBuyerDao BuyerDao { get; set; }
		IDistributorDao DistributorDao { get; set; }
		ICartDao CartDao { get; set; }
	}
}
