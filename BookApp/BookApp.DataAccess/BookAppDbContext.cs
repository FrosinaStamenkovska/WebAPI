using BookApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookApp.DataAccess
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions options): base(options) 
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id)
                .HasName("PrimaryKey_Id");

            modelBuilder.Entity<Book>()
                .Property(x => x.Title)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(x => x.Author)
                .HasMaxLength(250)
                .IsRequired();

            //SEED
            modelBuilder.Entity<Book>().HasData(new List<Book>
            {
                new Book
            {
                Id = 1,
                Author = "William Shakespeare",
                Title = "Hamlet"
            },
            new Book
            {
                Id = 2,
                Author = "J. K. Rowling",
                Title = "Harry Potter"
            },
            new Book
            {
                Id = 3,
                Author = "Leo Tolstoy",
                Title = "War and Peace"
            },
            new Book
            {
                Id = 4,
                Author = "Paulo Coelho",
                Title = "The Alchemist"
            },
            new Book
            {
                Id = 5,
                Author = "George R. R. Martin",
                Title = "Game of Thrones"

            },
            new Book
            {
                Id = 6,
                Author = "Paulo Coelho",
                Title = "Eleven minutes"
            },
            new Book
            {
                Id = 7,
                Author = "Herbert George Wells",
                Title = "The War of the Worlds"
            }
            });
        }
    }
}