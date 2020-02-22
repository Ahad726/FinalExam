using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core.Service
{
    public interface IFileService
    {
        void AddFile(FileEntity fileEntity);
        IEnumerable<FileEntity> GetFiles(
           int pageIndex,
           int pageSize,
           string searchText,
           out int total,
           out int totalFiltered);
    }
}
