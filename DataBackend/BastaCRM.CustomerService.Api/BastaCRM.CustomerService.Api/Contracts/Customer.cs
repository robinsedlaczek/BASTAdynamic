using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastaCRM.CustomerService.Api
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

    }
}
