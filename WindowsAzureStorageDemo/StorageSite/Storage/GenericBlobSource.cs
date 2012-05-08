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
    public class GenericBlobSource
    {
        private CloudBlobContainer _container;
        const string _connectionString = "";

        public GenericBlobSource(string connectionStringName)
        {
            var connectionString = RoleEnvironment.IsAvailable
                ? RoleEnvironment.GetConfigurationSettingValue(connectionStringName)
                : ConfigurationManager.AppSettings[connectionStringName];

            _container =
                CloudStorageAccount
                    .Parse(connectionString)
                    .CreateCloudBlobClient()
                    .GetContainerReference("uploadedfiles");

            _container.CreateIfNotExist();

            _container.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        public GenericBlobSource GetFileList(Action<IEnumerable<string>> callback)
        {
            var blobs = new List<string>();
            blobs.AddRange(
                this._container.ListBlobs().Select(x =>
                    x.Uri.AbsoluteUri));
            if (callback != null)
                callback(blobs);
            return this;
        }

        public GenericBlobSource SaveToBlobStorage(Stream stream, string filename, Action<Uri> callback)
        {
            var url = string.Empty;

            CloudBlob blob = this._container.GetBlobReference(filename);
            blob.UploadFromStream(stream);

            if (callback != null)
                callback(blob.Uri);

            return this;
        }
    }
}
