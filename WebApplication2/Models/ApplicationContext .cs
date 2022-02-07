using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
public class ApplicationContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Series> Series { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;

    public ApplicationContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
                .HasMany(c => c.Stores)
                .WithMany(s => s.Books)
                .UsingEntity<BooksStores>(
            j => j
                    .HasOne(pt => pt.Store)
                    .WithMany(t => t.BooksStores)
                    .HasForeignKey(pt => pt.StoreId),
            j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.BooksStores)
                    .HasForeignKey(pt => pt.BookId));
    }


}

