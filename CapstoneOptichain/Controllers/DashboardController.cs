using CapstoneOptichain.Data;
using CapstoneOptichain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace CapstoneOptichain.Controllers
{
	public class DashboardController : Controller
	{
		ProjectContext projectContext = new ProjectContext();
		// GET: DashboardController
		public ActionResult Index()
		{
			return View();
		}


		public ActionResult Index2()
		{
			return View("Index2");
		}
		public ActionResult Index3()
		{
			return View("Index3");
		}
		public ActionResult Index4() 
		{
			return View("Index4");
		}




		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var manager = projectContext.Managers
					.FirstOrDefault(m => m.email == model.Email && m.password == model.Password);

				if (manager != null)
				{
					HttpContext.Session.SetInt32("ManagerId", manager.ID);
					HttpContext.Session.SetString("Role", "Manager");
					return RedirectToAction("Index3"); 
				}

				var worker = projectContext.Workers
					.FirstOrDefault(w => w.email == model.Email && w.password == model.Password);

				if (worker != null)
				{
					HttpContext.Session.SetInt32("WorkerId", worker.ID);
					HttpContext.Session.SetString("Role", worker.role); 
					return RedirectToAction("Index3"); 
				}

				ViewBag.Error = "Invalid email or password.";
			}

			return View("Index"); 
		}








		[HttpPost]
		public ActionResult Create(IFormCollection form)
		{
			string name = form["name"];
			string email = form["email"];
			string password = form["password"];
			string phoneNumber = form["phone_number"];
			string role = form["role"].ToString().ToLower();

			if (role == "worker")
			{
				var worker = new Worker
				{
					name = name,
					email = email,
					password = password,
					Phone_number = phoneNumber,
					role = role
				};

				projectContext.Workers.Add(worker);
				projectContext.SaveChanges();
				return RedirectToAction("Index3");
			}
			else if (role == "manager")
			{
				var manager = new Manager
				{
					name = name,
					email = email,
					password = password,
					phone = phoneNumber
				};

				projectContext.Managers.Add(manager);
				projectContext.SaveChanges();
				return RedirectToAction("Index3");
			}
			else
			{
				ViewBag.Error = "Role must be either 'worker' or 'manager'";
				return View("Index2");
			}
		}






		[HttpPost]
		public IActionResult SendVerificationCode(string email)
		{
			HttpContext.Session.SetString("ResetEmail", email);
			HttpContext.Session.SetString("ResetCode", "123456"); 

			return Json(new { success = true });
		}

		// Verify code
		[HttpPost]
		public IActionResult VerifyCode(string code)
		{
			HttpContext.Session.SetString("CodeVerified", "true");
			return Json(new { success = true });
		}

		[HttpPost]
		public IActionResult ResetPassword(string newPassword)
		{
			var email = HttpContext.Session.GetString("ResetEmail");
			var codeVerified = HttpContext.Session.GetString("CodeVerified");

			if (codeVerified == "true")
			{
				return Json(new { success = true });
			}

			return Json(new { success = false, message = "Code not verified." });
		}
	}
}

