using Autofac;
using FinalExam.Core;
using FinalExam.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Models
{
    public class FileUpdateModel
    {

        private IFileService _fileService;

        public FileUpdateModel()
        {
            _fileService = Startup.AutofacContainer.Resolve<IFileService>();
        }

        public FileUpdateModel(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void AddNewFile(string filename)
        {
            _fileService.AddFile(
                new FileEntity
                {
                    FileName = filename,
                    FileUploadDate = DateTime.Now,
                    Status = "Pending"

                }
            );
        }


    }
}
