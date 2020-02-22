using FinalExam.Core.Context;
using FinalExam.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FinalExam.Core
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

        public void Add(FileEntity file)
        {
            _context.Files.Add(file);
        }

        public void Save()
        {
            _context?.SaveChanges();
        }


        public IEnumerable<FileEntity> Get(
           out int total, out int totaldisplay,
           Expression<Func<FileEntity, bool>> filter = null,
           Func<IQueryable<FileEntity>, IOrderedQueryable<FileEntity>> orderBy = null,
           string includeProperties = "", int pageindex = 1, int pageSize = 10, bool isTrackingOff = false)
        {

            var query = Files.AsQueryable();
            total = query.Count();
            totaldisplay = total;

            if (filter != null)
            {
                query = query.Where(filter);
                totaldisplay = query.Count();
            }

            foreach (var includerProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includerProperty);
            }

            IQueryable<FileEntity> result = null;

            if (orderBy != null)
            {
                result = orderBy(query).Skip((pageindex - 1) * pageSize).Take(pageSize);
            }

            else
            {
                result = query.Skip((pageindex - 1) * pageSize).Take(pageSize);
            }

            if (isTrackingOff)
                return result?.AsNoTracking().ToList();
            else
                return result?.ToList();
        }

    }
}
