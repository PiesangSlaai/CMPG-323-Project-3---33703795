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
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly SuperStoreContext _context;

        public CustomerRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetByConditionAsync(Expression<Func<Customer, bool>> condition)
        {
            return await _context.Customers.Where(condition).ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(object id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task CreateAsync(Customer entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(Expression<Func<Customer, bool>> condition)
        {
            return _context.Customers.Any(condition);
        }
    }
}
