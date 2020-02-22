using FinalExam.Core.Context;
using FinalExam.Core.Repository;
using FinalExam.Core.UnitWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private  FileContext _context;
        public IFileRepository  FileRepositroy { get; set; }
        
        public UnitOfWork(string connectionString, string migrationAssemblyName)           
        {
            _context = new FileContext(connectionString, migrationAssemblyName);
            FileRepositroy = new FileRepository(_context);
        }
    }
}
