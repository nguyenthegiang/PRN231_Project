using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public VideoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //Function [Watch Video]
        [HttpGet("GetVideoContent")]
        public async Task<IActionResult> GetVideoContent(string fileName)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "Video/") + fileName;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            //enableRangeProcessing = true
            return File(memory, "application/octet-stream", Path.GetFileName(path), true); 
        }
    }
}
