using Image_Compression.Application.AzureKeyVault;
using Image_Compression.Application.BlobStorage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Compression.Application.CompressedImage
{
    public class CompressedImageAppService : ICompressedImageAppService
    {
        private readonly IBlobStorageAppService _blobStorageAppService;
        public CompressedImageAppService(IBlobStorageAppService blobStorageAppService)
        {
            _blobStorageAppService = blobStorageAppService;
        }

        public Task<string> CompressImage(string FileName, string containerName, int Quality, Stream File, string key)
        {
            using (Bitmap bmp1 = new Bitmap(File))
            {
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                System.Drawing.Imaging.Encoder QualityEncoder = System.Drawing.Imaging.Encoder.Quality;

                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(QualityEncoder, Quality);

                myEncoderParameters.Param[0] = myEncoderParameter;
                Stream stream = new MemoryStream();
                bmp1.Save(stream, jpgEncoder, myEncoderParameters);
                return _blobStorageAppService.Upload(FileName:FileName,ContainerName:containerName,File:File,ConnectionString: KeyVaultConnection.ImageConfigurationGetBlobConnection(key));
            }
        }

        public ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}