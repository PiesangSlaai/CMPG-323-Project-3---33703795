using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        bool CustomerExists(int id);
    }
}
