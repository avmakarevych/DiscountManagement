using DiscountManagement.Core.Entities;
using DiscountManagement.Core.Interfaces;
using DiscountManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetByOrderId(Guid orderId)
        {
            // Припускаючи, що у вас є відношення між таблицями Products та Orders, 
            // ви можете використовувати наступний запит:
            return _context.Products.Where(p => p.OrderId == orderId).ToList();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetByOrderIdAsync(Guid orderId)
        {
            return await _context.Products.Where(p => p.OrderId == orderId).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}