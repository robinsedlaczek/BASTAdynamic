using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastaCRM.CustomerService.Api.Contracts
{
    public class CustomerAccess : ICustomerAccess
    {
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Hans", LastName = "Zimmer"},
                new Customer {Id = 2, FirstName = "Peter", LastName = "Lustig"}
            };
            return await Task.FromResult(customers);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await Task.FromResult(new Customer { Id = 2, FirstName = "Peter", LastName = "Lustig" });
        }

        public Task CreateCustomer(Customer customerEntity)
        {
            return Task.CompletedTask;
        }

        public Task UpdateCustomer(Customer customerEntity)
        {
            return Task.CompletedTask;
        }

        public Task DeleteCustomer(int id)
        {
            return Task.CompletedTask;
        }
    }
}
