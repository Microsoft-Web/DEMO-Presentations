using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageSite.Models
{
	public class TaskItem : TableServiceEntity
	{
		public TaskItem()
		{
			base.PartitionKey = "default";
			base.RowKey = Environment.TickCount.ToString();
			base.Timestamp = DateTime.Now;
		}

		public string Details { get; set; }
	}
}