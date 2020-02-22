using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core.Repository
{
    public interface IFileRepository
    {
        void Add(FileEntity file);
        void Save();
    }
}
