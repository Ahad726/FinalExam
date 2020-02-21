using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core.Context
{
    public interface IFileContext
    {
        DbSet<FileEntity> Files { get; set; }
    }
}
