using FinalExam.Core.Context;
using FinalExam.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.Core
{
    public class FileRepository : IFileRepository
    {
        private FileContext _context;
        public FileRepository(FileContext context)
        {
            _context = context;
        }

        public void Add(FileEntity file)
        {
            _context.Files.Add(file);
        }

        public void Save()
        {
            _context?.SaveChanges();
        }

    }
}
