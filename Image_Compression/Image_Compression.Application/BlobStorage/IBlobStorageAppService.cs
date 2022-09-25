using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Compression.Application.BlobStorage
{
    public interface IBlobStorageAppService
    {
        Task<string> Upload(string FileName, string ContainerName,Stream File, string ConnectionString);
    }
}
