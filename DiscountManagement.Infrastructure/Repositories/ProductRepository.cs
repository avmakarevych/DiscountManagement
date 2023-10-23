using DiscountManagement.Core.Entities;
using DiscountManagement.Core.Interfaces;
using DiscountManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}