using FileWorkerService.Entity;
using FileWorkerService;
using FileWorkerService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FileWorkerService.Repository
{
    public class FileRepository : IFileRepository
    {
        private FileContext _context;
        public DbSet<FileEntity> Files { get; set; }
        public FileRepository(FileContext context)
        {
            _context = context;
            Files = _context.Set<FileEntity>();
        }
        public string GetFileName()
        {
            var filename = Files.Where(s => s.Status == "Pending").Select(x => x.FileName).FirstOrDefault();

            return filename;
        }


    }
}
