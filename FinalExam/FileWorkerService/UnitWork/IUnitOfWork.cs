using FileWorkerService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWorkerService.UnitWork
{
    public interface IUnitOfWork 
    {
      IFileRepository FileRepositroy { get; set; }
        void Save();

    }
}
