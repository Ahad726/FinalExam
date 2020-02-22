using FileWorkerService.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileWorkerService
{
    public class FileContext : DbContext
    {
        private string _connectionString;

        public FileContext()
        {
            _connectionString = "Server=103.104.242.155;Database=Db8;User Id=demo;Password =123456;";
        }
        public FileContext(string connectionString)
        {
            _connectionString = "Server=103.104.242.155;Database=Db8;User Id=demo;Password =123456;";
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<FileEntity> Files { get; set; }
    }
}
