using BookShop.DAL;
using BookShop.Models;
using BookShop.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace BookShop.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private DaoContainer _daoContainer;

		public AccountController(DaoContainer daoContainer)
		{
			this._daoContainer = daoContainer;
		}

		[HttpGet]
		public ActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SignIn(SignInViewModel signIn)
		{
			const string ErrorKey = "SignIn_Error";
			if (ViewData.ModelState.IsValid)
			{
				Buyer buyer = _daoContainer.BuyerDao.GetByEmail(signIn.Email);
				if (buyer != null && buyer.Password == signIn.Password)
				{
					FormsAuthentication.SetAuthCookie(buyer.Id.ToString(), signIn.StaySignedIn);
					return RedirectToAction("Index", "Buyer");
				}

				Distributor distributor = _daoContainer.DistributorDao.GetByEmail(signIn.Email);
				if (distributor != null && distributor.Password == signIn.Password)
				{
					FormsAuthentication.SetAuthCookie(distributor.Email, signIn.StaySignedIn);
					return RedirectToAction("Index", "Distributor");
				}

				ViewData.ModelState.AddModelError(ErrorKey, "Incorrect password or email");
				return View();
			}
			else
			{
				ViewData.ModelState.AddModelError(ErrorKey, "Invalid details, please try again");
				return View();
			}
		}

		[HttpGet]
		public ActionResult SignUpBuyer()
		{
			return View();
		}
		[HttpGet]
		public ActionResult SignUpDistributor()
		{
			return View();
		}

		[HttpPost]
		public ActionResult SignUpBuyer(SignUpViewModel signUp)
		{
			const string ErrorKey = "SignUp_Error";
			if (ViewData.ModelState.IsValid)
			{
				if (_daoContainer.BuyerDao.Add(new Buyer() { Name = signUp.Name, Email = signUp.Email, Password = signUp.Password }))
				{
					FormsAuthentication.SetAuthCookie(signUp.Email, true);
					return RedirectToAction("Index", "Buyer");
				}
				else
				{
					ViewData.ModelState.AddModelError(ErrorKey, "Internal Error");
					return View();
				}
			}

			ViewData.ModelState.AddModelError(ErrorKey, "Invalid details, please try again");
			return View();
		}

		[HttpPost]
		public ActionResult SignUpDistributor(SignUpViewModel signUp)
		{
			const string ErrorKey = "SignUp_Error";
			if (ViewData.ModelState.IsValid)
			{
				if (_daoContainer.DistributorDao.Add(new Distributor() { Name = signUp.Name, Email = signUp.Email, Password = signUp.Password }))
				{
					FormsAuthentication.SetAuthCookie(signUp.Email, true);
					return RedirectToAction("Index", "Distributor");
				}
				else
				{
					ViewData.ModelState.AddModelError(ErrorKey, "Internal Error");
					return View();
				}
			}

			ViewData.ModelState.AddModelError(ErrorKey, "Invalid details, please try again");
			return View();
		}

		[HttpPost]
		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("SignIn", "Account");
		}
	}
}