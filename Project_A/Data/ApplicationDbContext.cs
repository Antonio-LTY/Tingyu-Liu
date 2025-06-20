using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LibraryBranch> LibraryBranches { get; set; }
    }
}

