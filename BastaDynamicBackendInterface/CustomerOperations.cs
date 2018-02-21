using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1
{
    public class CustomerOperations : HttpHelper
    {
        public async Task UpdateCustomer(CustomerProxy customer)
        {
            await Post(customer, "PUT");
        }

        public async Task DeleteCustomer(CustomerProxy customer)
        {
            await Post(customer, "DELETE");
        }

        public async Task AddCustomer(CustomerProxy customer)
        {
            await Post(customer, "POST");
        }

        public async Task<IEnumerable<CustomerProxy>> GetAllCustomers()
        {
            return (IEnumerable<CustomerProxy>) await Get();
        }
    }
}
