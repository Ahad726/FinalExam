using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using FinalExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile formfile)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(formfile.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(formfile.FileName)}";

            var path = $"upload/{randomName}{Path.GetExtension(formfile.FileName)}";

            if (!System.IO.File.Exists(path))
            {
                using (var txtFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = formfile.OpenReadStream())
                    {
                        uploadedfile.CopyTo(txtFile);
                    }
                }
            }
            var client = new AmazonS3Client();

            var file = new FileInfo(path);
            var request = new PutObjectRequest
            {
                BucketName = "atmahad",
                FilePath = file.FullName,
                Key = newFileName
            };

           var response = await client.PutObjectAsync(request);


                file.Delete();


            var model = new FileUpdateModel();
            model.AddNewFile(newFileName);

            return View();

        }
    }
}