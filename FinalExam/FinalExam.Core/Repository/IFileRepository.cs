using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace FinalExam.Core.Repository
{
    public interface IFileRepository
    {
        void Add(FileEntity file);
        void Save();

        IEnumerable<FileEntity> Get(
           out int total, out int totaldisplay,
           Expression<Func<FileEntity, bool>> filter = null,
           Func<IQueryable<FileEntity>, IOrderedQueryable<FileEntity>> orderBy = null,
           string includeProperties = "", int pageindex = 1, int pageSize = 10, bool isTrackingOff = false);
        string GetFileName();
    }
}
