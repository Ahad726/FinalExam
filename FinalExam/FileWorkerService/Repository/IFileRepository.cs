using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace FileWorkerService.Repository
{
    public interface IFileRepository
    {      
        string GetFileName();
    }
}
