using Autofac;
using FinalExam.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExam.Models
{
    public class FileViewModel
    {
        private IFileService _fileService;

        public FileViewModel()
        {
            _fileService = Startup.AutofacContainer.Resolve<IFileService>();
        }

        public FileViewModel(IFileService fileService)
        {
            _fileService = fileService;
        }

        public object GetFile(DataTablesAjaxRequestModel tableModel)
        {
            int total = 0;
            int totalFiltered = 0;
            var records = _fileService.GetFiles(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                out total,
                out totalFiltered);

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalFiltered,
                data = (from record in records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.FileName,
                                record.FileUploadDate.ToString(),
                                record.Status
                        }
                    ).ToArray()

            };
        }
    }
}
