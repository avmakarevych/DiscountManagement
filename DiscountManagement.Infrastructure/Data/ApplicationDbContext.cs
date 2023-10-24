using Microsoft.EntityFrameworkCore;
using DiscountManagement.Core.Entities;


namespace DiscountManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Customer>()
            .Property(c => c.Discount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
    }

    public static void Seed(AppDbContext dbContext)
    {
        if (!dbContext.Customers.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                var customer = new Customer
                {
                    PersonalCode = $"PC-{i}",
                    Name = $"Клієнт {i}",
                    Email = $"client{i}@test.com",
                    Address = $"Адреса {i}",
                    Discount = i
                };

                dbContext.Customers.Add(customer);
                
                var order = new Order
                {
                    CustomerId = customer.Id,
                    OrderDate = DateTime.Now.AddDays(-i),
                    TotalAmount = i * 100
                };

                dbContext.Orders.Add(order);

                for (int j = 1; j <= 3; j++)
                {
                    var product = new Product
                    {
                        Name = $"Продукт {j}",
                        Description = $"Опис продукту {j}",
                        Price = j * 10,
                        OrderId = order.Id
                    };

                    dbContext.Products.Add(product);
                }
            }


            dbContext.SaveChanges();
        }
    }

}