using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using System.Linq.Expressions;
using System.Configuration;

namespace WindowsAzureStorageHelpers
{
    public class GenericTableSource<T> where T : TableServiceEntity
    {
        static string tableName = typeof(T).Name;
        private string connectionStringName = 
            "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";
        private static CloudStorageAccount storageAccount;
        private CloudTableClient tableClient;
        public TableServiceContext TableContext { get; set; }

        public GenericTableSource(string connectionString)
        {
            this.connectionStringName = !string.IsNullOrEmpty(connectionString) ? connectionString : connectionStringName;

            string cs = RoleEnvironment.IsAvailable
                ? RoleEnvironment.GetConfigurationSettingValue(connectionStringName)
                : ConfigurationManager.AppSettings[connectionStringName];

            storageAccount = CloudStorageAccount.Parse(cs);
			
            tableClient = new CloudTableClient(storageAccount.TableEndpoint.AbsoluteUri,
                storageAccount.Credentials);
            tableClient.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
            tableClient.CreateTableIfNotExist(tableName);
            TableContext = TableContext ?? tableClient.GetDataServiceContext();
        }

        public GenericTableSource()
            : this(string.Empty)
        {
        }

        public IEnumerable<T> GetEntries(Expression<Func<T, bool>> query)
        {
			var r = new List<T>();
			r.AddRange(TableContext.CreateQuery<T>(tableName).Where(query));
            return r;
        }

        public GenericTableSource<T> Add(T entry)
        {
            TableContext.AddObject(tableName, entry);
			return this;
        }

		public GenericTableSource<T> Save()
        {
            TableContext.SaveChanges(System.Data.Services.Client.SaveChangesOptions.Batch);
			return this;
        }
    }
}
