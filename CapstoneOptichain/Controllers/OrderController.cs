using CapstoneOptichain.Data;
using CapstoneOptichain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneOptichain.Controllers
{
	public class OrderController : Controller
	{
		ProjectContext projectContext = new ProjectContext();
		// GET: OrderController
		public ActionResult Index()
		{
			var x = projectContext.RawMaterials.ToList();
			return View(x);
		}
		public ActionResult Index2()
		{
			return View("Index2");
		}


		[HttpPost]
		public ActionResult Create(RawMaterial material)
		{
			projectContext.RawMaterials.Add(material);
			projectContext.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: OrderController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: OrderController/Edit/5
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

		// GET: OrderController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: OrderController/Delete/5
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
