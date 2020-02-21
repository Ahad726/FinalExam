using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core.UnitWork
{
    public interface IUnitOfWork 
    {
         DbSet<FileEntity> Files { get; set; }

    }
}
