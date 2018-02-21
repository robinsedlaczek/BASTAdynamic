using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastaCRM.CustomerService.Api.Contracts
{
    public interface ICustomerAccess
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(int id);

        Task CreateCustomer(Customer customerEntity);
        Task UpdateCustomer(Customer customerEntity);
        Task DeleteCustomer(int id);
    }
}
