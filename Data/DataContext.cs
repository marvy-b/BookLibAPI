
using BookLibAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibAPI.Data
{
    public class DataContext : DbContext
    {
       
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Programming\Temp\BookLib.db");
    }
}

