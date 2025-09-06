using Microsoft.EntityFrameworkCore;
using NorthwindTest.Modles;

namespace NorthwindTest.Data;

public class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }
    
    public DbSet<CustomerItem> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerItem>(entity =>
        {
            entity.ToTable("Customers");

            // 主鍵
            entity.HasKey(e => e.CustomerID);

            // 欄位對映
            entity.Property(e => e.CustomerID)
                  .HasColumnName("CustomerID")
                  .HasMaxLength(5)
                  .IsRequired(); // Northwind 的主鍵是 nvarchar(5)

            entity.Property(e => e.CompanyName)
                  .HasMaxLength(40);

            entity.Property(e => e.ContactName)
                  .HasMaxLength(30);

            entity.Property(e => e.ContactTitle)
                  .HasMaxLength(30);

            entity.Property(e => e.Address)
                  .HasMaxLength(60);

            entity.Property(e => e.City)
                  .HasMaxLength(15);

            entity.Property(e => e.Region)
                  .HasMaxLength(15);

            entity.Property(e => e.PostalCode)
                  .HasMaxLength(10);

            entity.Property(e => e.Country)
                  .HasMaxLength(15);

            entity.Property(e => e.Phone)
                  .HasMaxLength(24);

            entity.Property(e => e.Fax)
                  .HasMaxLength(24);
        });
    }

}
