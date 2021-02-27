using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Author { get; set; }
		public string Publisher { get; set; }
		public string Genre { get; set; }
		public double Price { get; set; }
		public int DistributorId { get; set; }
		public Distributor Distributor { get; set; }
		public string Language { get; set; }

		public override bool Equals(object obj)
		{
			if (typeof(Book) != obj.GetType())
				return false;
			Book b = (Book)obj;
			if (
				b.Name == Name &&
				b.Description == Description &&
				b.Author == Author &&
				b.Publisher == Publisher &&
				b.Language == Language &&
				b.Price == Price &&
				b.Genre == Genre &&
				b.DistributorId == DistributorId
			)
				return true;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}