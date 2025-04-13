using CapstoneOptichain.Data;
using CapstoneOptichain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneOptichain.Controllers
{
	public class SuppliersController : Controller
	{
		ProjectContext projectContext = new ProjectContext();
		// GET: SuppliersController
		public ActionResult Index()
		{
			var x = projectContext.Distributions.ToList();
			return View(x);
		}



		[HttpPost]
		public ActionResult Create(Distribution distribution)
		{
			projectContext.Distributions.Add(distribution);
			projectContext.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: SuppliersController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SuppliersController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SuppliersController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SuppliersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
