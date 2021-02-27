using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Cart
	{
		public int BookId { get; set; }
		public Book Book { get; set; }
		public int BuyerId { get; set; }
		public Buyer Buyer { get; set; }
	}
}