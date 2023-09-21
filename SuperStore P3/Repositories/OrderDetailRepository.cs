using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Repositories;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly SuperStoreContext _context;

        public OrderDetailRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
        }

        public async Task CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetailAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }

        public bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailsId == id);
        }
    }
}

