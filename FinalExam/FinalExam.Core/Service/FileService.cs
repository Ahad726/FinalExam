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
    }
}
