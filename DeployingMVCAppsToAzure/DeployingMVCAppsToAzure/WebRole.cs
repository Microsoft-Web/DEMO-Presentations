using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace DeployingMVCAppsToAzure
{
	public class WebRole : RoleEntryPoint
	{
		public override bool OnStart()
		{
			return base.OnStart();
		}

		public override void OnStop()
		{
			base.OnStop();
		}

		public override void Run()
		{
			base.Run();
		}
	}
}