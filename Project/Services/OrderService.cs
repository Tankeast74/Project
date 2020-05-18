using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
    }
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
