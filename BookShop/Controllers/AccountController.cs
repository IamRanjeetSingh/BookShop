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

		[HttpGet]
		public ActionResult SignInModal()
		{
			return PartialView("_SignIn");
		}

		[HttpPost]
		public ActionResult SignIn(SignInViewModel signIn)
		{
			const string ErrorKey = "SignIn_Error";
			if (ViewData.ModelState.IsValid)
			{
				Buyer buyer = _daoContainer.BuyerDao.GetByCredentials(signIn.Email, signIn.Password);
				Distributor distributor = buyer == null ? _daoContainer.DistributorDao.GetByCredentials(signIn.Email, signIn.Password) : null;
				if (buyer != null)
				{
					FormsAuthentication.SetAuthCookie(buyer.Id.ToString(), signIn.StaySignedIn);
					return RedirectToAction("Index", "Buyer");
				}
				else if (distributor != null)
				{
					FormsAuthentication.SetAuthCookie(distributor.Id.ToString(), signIn.StaySignedIn);
					return RedirectToAction("Index", "Distributor");
				}
				else
				{
					ViewData.ModelState.AddModelError(ErrorKey, "Incorrect Email or Password");
					return PartialView("_SignIn");
				}
			}
			else
			{
				ViewData.ModelState.AddModelError(ErrorKey, "Invalid details, please try again");
				return View();
			}
		}

		[HttpGet]
		public ActionResult SignUp()
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