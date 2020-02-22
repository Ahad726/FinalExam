using FileWorkerService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWorkerService.UnitWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private  FileContext _context;
        public IFileRepository  FileRepositroy { get; set; }

        public UnitOfWork()
        {
            var connectionString = "Server=103.104.242.155;Database=Db8;User Id=demo;Password =123456;";
            _context = new FileContext(connectionString);

            FileRepositroy = new FileRepository(_context);
        }

        public void Save() => _context.SaveChanges();
    }
}
