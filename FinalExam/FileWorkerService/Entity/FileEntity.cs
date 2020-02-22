using System;
using System.Collections.Generic;
using System.Text;

namespace FileWorkerService.Entity
{
    public class FileEntity
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime FileUploadDate { get; set; }
        public string Status { get; set; }
    }
}
