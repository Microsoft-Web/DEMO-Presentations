using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace DeployingMVCAppsToAzure.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			return View();
		}

		public ActionResult WebAppSetting()
		{
			ViewBag.Message = 
                ConfigurationManager.AppSettings["MyWebAppAppSetting"];
			return View();
		}

		public ActionResult WindowsAzureAppSetting()
		{
			ViewBag.Message = 
                RoleEnvironment.GetConfigurationSettingValue("MyAzureRoleAppSetting");
			return View();
		}

		public ActionResult GetMessageSafely()
		{
			if(!RoleEnvironment.IsAvailable)
				ViewBag.Message = ConfigurationManager.AppSettings["MyWebAppAppSetting"];
			else
				ViewBag.Message = RoleEnvironment.GetConfigurationSettingValue("MyAzureRoleAppSetting");

			return View();
		}
	}
}
