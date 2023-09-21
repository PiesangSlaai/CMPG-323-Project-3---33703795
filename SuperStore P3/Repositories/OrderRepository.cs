using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;

namespace Repositories
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly SuperStoreContext _context;

        public OrderRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByConditionAsync(Expression<Func<Order, bool>> condition)
        {
            return await _context.Orders.Where(condition).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(object id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task CreateAsync(Order entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _context.Orders.FindAsync(id);
            if (entity != null)
            {
                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(Expression<Func<Order, bool>> condition)
        {
            return _context.Orders.Any(condition);
        }
    }
}

