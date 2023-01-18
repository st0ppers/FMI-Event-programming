using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Library.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
