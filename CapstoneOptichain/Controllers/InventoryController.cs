using CapstoneOptichain.Data;
using CapstoneOptichain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneOptichain.Controllers
{
	public class InventoryController : Controller
	{
		ProjectContext projectContext = new ProjectContext();
		// GET: InventoryController
		public ActionResult Index()
		{
			var x = projectContext.Productions.ToList();
			return View(x);
		}
		public ActionResult Index2()
		{
			return View("Index2");
		}


		[HttpPost]
		public IActionResult Create(Production product)
		{
			projectContext.Productions.Add(product);
			projectContext.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: InventoryController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: InventoryController/Edit/5
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

		// GET: InventoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: InventoryController/Delete/5
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
