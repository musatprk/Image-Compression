using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Compression.Application.CompressedImage
{
    public interface ICompressedImageAppService
    {
        public Task<string> CompressImage(string FileName, string ContainerName, int Quality, Stream File,string Key);
        public ImageCodecInfo GetEncoder(ImageFormat format);
    }
}
