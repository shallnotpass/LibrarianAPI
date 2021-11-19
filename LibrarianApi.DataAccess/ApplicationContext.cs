using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserCardEntry> UserCardEntries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAccounting> BooksAccounting { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            this.Books
                .Include(books => books.Author)
                .Include(books => books.BookAccounting)
                .Include(books => books.UserCardEntries)
                .ToList();
            this.UserCardEntries
                .Include(entry => entry.Book)
                .Include(entry => entry.User)
                .ToList();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(user => user.UserCardEntries)
                .WithOne(card => card.User);

            builder.Entity<Book>()
                .HasMany(book => book.UserCardEntries)
                .WithOne(card => card.Book);

        }
    }
}
