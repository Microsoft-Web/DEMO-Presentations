using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StorageSite.Models;
using WindowsAzureStorageHelpers;

namespace StorageSite.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            var tasks = new List<TaskItem>();

            try
            {
                tasks =
                    new GenericTableSource<TaskItem>("TaskList")
                        .GetEntries(x => true)
                        .ToList();
            }
            catch
            {
            }

            ViewBag.tasks = tasks;

            var blobs =
                new GenericBlobSource("Blobs")
                    .GetFileList(x => ViewBag.blobs = x);

			return View();
		}

		public ActionResult NewTask(string item)
		{
			var newItem = new TaskItem
			{
				Details = item
			};

			new GenericTableSource<TaskItem>("TaskList")
				.Add(newItem)
				.Save();

			return RedirectToAction("Index");
		}

		public ActionResult NewFile()
		{
			if (Request.Files != null)
			{
				var file = Request.Files[0];
				var stm = file.InputStream;
				var name = System.IO.Path.GetFileName(file.FileName);

				new GenericBlobSource("Blobs")
					.SaveToBlobStorage(stm, name, null);
			}

			return RedirectToAction("Index");
		}
	}
}
