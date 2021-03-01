using BookShop.DAL;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace BookShop
{
	public static class UnityDependencyInjection
	{
		public static IDependencyResolver GetDependencyResolver()
		{
			UnityContainer unityContainer = new UnityContainer();

			unityContainer.RegisterType<IBookDao, BookEfDao>();
			unityContainer.RegisterType<IBuyerDao, BuyerEfDao>();
			unityContainer.RegisterType<IDistributorDao, DistributorEfDao>();
			unityContainer.RegisterType<ICartDao, CartEfDao>();

			unityContainer.RegisterType<DaoContainer, DaoContainer>();

			return new UnityDependencyResolver(unityContainer);
		}
	}
}