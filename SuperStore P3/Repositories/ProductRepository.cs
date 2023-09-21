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
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly SuperStoreContext _context;

        public ProductRepository(SuperStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByConditionAsync(Expression<Func<Product, bool>> condition)
        {
            return await _context.Products.Where(condition).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(object id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task CreateAsync(Product entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public bool Exists(Expression<Func<Product, bool>> condition)
        {
            return _context.Products.Any(condition);
        }
    }
}

