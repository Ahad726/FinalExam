
using FileWorkerService.UnitWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWorkerService.Service
{
    public class FileService : IFileService
    {
        private IUnitOfWork _unitOfWork;

        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetFIleName()
        {
            return _unitOfWork.FileRepositroy.GetFileName();
        }
    }
}
