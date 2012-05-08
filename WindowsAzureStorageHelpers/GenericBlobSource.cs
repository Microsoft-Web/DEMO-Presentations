using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace WindowsAzureStorageHelpers
{
    public class GenericBlobSource<T>
    {
        private CloudBlobContainer _container;
        const string _connectionString = "";

        public void CreateStorageContainer(string connectionStringName)
        {
            var connectionString = RoleEnvironment.IsAvailable
                ? RoleEnvironment.GetConfigurationSettingValue(connectionStringName)
                : ConfigurationManager.AppSettings[connectionStringName];

            _container =
                CloudStorageAccount
                    .Parse(connectionString)
                    .CreateCloudBlobClient()
                    .GetContainerReference(connectionString);

            _container.CreateIfNotExist();

            _container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        public string SaveImageToBlobStorage(T target)
        {
            var url = string.Empty;

            using (var ms = new MemoryStream())
            {
                CloudBlob blob = this._container.GetBlobReference(Environment.TickCount.ToString());
                blob.UploadFromStream(ms);

                url = blob.Uri.AbsoluteUri;

                ms.Close();
            }

            return url;
        }
    }
}
