using Image_Compression.Application.CompressedImage;
using Microsoft.AspNetCore.Mvc;

namespace Image_Compression.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImageConfiguration : Controller
    {

        private readonly ICompressedImageAppService _compressedImageAppService;

        public ImageConfiguration(ICompressedImageAppService compressedImageAppService)
        {
            _compressedImageAppService = compressedImageAppService;
        }

        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue, ValueLengthLimit = int.MaxValue)]
        [HttpPost(Name = "CompressedImage")]
        public async Task<IActionResult> CompressedImage()
        {
            var FileName = Request.Form.ContainsKey("FileName") == true ? Request.Form["FileName"].ToString().ToLower() : string.Empty;
            var ContainerName = Request.Form.ContainsKey("ContainerName") == true ? Request.Form["ContainerName"].ToString().ToLower() : string.Empty;
            var Quality = Request.Form.ContainsKey("Quality") == true ? Request.Form["Quality"].ToString() : string.Empty;
            var Key = Request.Form.ContainsKey("Key") == true ? Request.Form["Key"].ToString() : string.Empty;
            var Files = Request.Form.Files.ToList().Count > 0 ? Request.Form.Files.ToList() : null;
            var result = "";
            if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(ContainerName) || string.IsNullOrEmpty(Quality) || string.IsNullOrEmpty(Key) || Files == null || Files.Count < 1)
                return new BadRequestObjectResult(new { ErrorCode = "Missing Parameter Make sure to send [FileName,ContainerName,Quality,Key,Files] parameters." });

            foreach (var item in Files)
            {
                string ext = Path.GetExtension(item.FileName).ToUpper();
                if (ext == ".PNG" || ext == ".JPG")
                {
                    result = await _compressedImageAppService.CompressImage(FileName + "/" + item.FileName, ContainerName, int.Parse(Quality), item.OpenReadStream(), Key);
                    if (result == null) { return new BadRequestObjectResult(new { ErrorCode = "Something Went Wrong" }); }
                    else return new OkObjectResult(result);
                }
                else return new BadRequestObjectResult(new { ErrorCode = "This is not picture" });

            }

            return new OkObjectResult(result);
        }
    }
}
