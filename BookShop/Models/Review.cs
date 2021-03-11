using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Review
	{
		public int Id { get; set; }
		public int BookId { get; set; }
		public Book Book { get; set; }
		public int BuyerId { get; set; }
		public Buyer Buyer { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; }
	}
}