using DiscountManagement.Core.Entities;
using DiscountManagement.Core.Interfaces;
using DiscountManagement.Infrastructure.Data;

namespace DiscountManagement.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Order Get(Guid id)
        {
            return _context.Orders.Find(id);
        }

        public IEnumerable<Order> GetByCustomerId(Guid customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}