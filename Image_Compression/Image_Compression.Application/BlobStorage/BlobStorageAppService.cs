using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Image_Compression.Application.BlobStorage
{
    public class BlobStorageAppService : IBlobStorageAppService
    {
        public async Task<string> Upload(string FileName, string ContainerName, Stream File, string ConnectionString)
        {
            BlobServiceClient _blobServiceClient = new BlobServiceClient(ConnectionString);

            var containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
            await containerClient.CreateIfNotExistsAsync();
            await containerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
            var blobClient = containerClient.GetBlobClient(FileName);

            BlobHttpHeaders blobHttpHeaders = new BlobHttpHeaders(); 
            File.Position = 0;
            blobClient.Upload(File, blobHttpHeaders);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
