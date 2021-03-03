using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookShop.DAL
{
	public enum BookOrder
	{
		Price,
		PriceDesc,
		Date,
		DateDesc,
		Rating,
		RatingDesc
	}
}