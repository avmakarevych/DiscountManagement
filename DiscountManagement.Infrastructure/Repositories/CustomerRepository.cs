using DiscountManagement.Core.Entities;
using DiscountManagement.Core.Interfaces;
using DiscountManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public Customer Get(Guid customerId)
    {
        return _context.Customers.Include(c => c.Orders)
            .SingleOrDefault(c => c.Id == customerId);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.Include(c => c.Orders).ToList();
    }

    public void Remove(Guid customerId)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer == null) return;

        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    public void Update(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        _context.Customers.Update(customer);
        _context.SaveChanges();
    }
    public async Task AddAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> GetAsync(Guid id)
    {
        return await _context.Customers.Include(c => c.Orders)
            .SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.Include(c => c.Orders).ToListAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return;

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}