using FinalExam.Core.Service;
using FinalExam.Core.UnitWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core
{
    public class FileService : IFileService
    {
        private IUnitOfWork _unitOfWork;

        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFile(FileEntity fileEntity)
        {

            _unitOfWork.FileRepositroy.Add(fileEntity);
            _unitOfWork.FileRepositroy.Save();
        }

        public IEnumerable<FileEntity> GetFiles(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered)
        {
            return _unitOfWork.FileRepositroy.Get(
                out total,
                out totalFiltered,
                x => x.FileName.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);
        }

        public string GetFIleName()
        {
            return _unitOfWork.FileRepositroy.GetFileName();
        }
    }
}
