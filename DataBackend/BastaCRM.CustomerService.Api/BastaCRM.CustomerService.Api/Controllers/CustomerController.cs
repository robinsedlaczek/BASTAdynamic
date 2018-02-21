using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BastaCRM.CustomerService.Api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Table;

namespace BastaCRM.CustomerService.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerAccess _customerAccess;

        public CustomerController(ICustomerAccess customerAccess)
        {
            _customerAccess = customerAccess;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allCustomers = await _customerAccess.GetAllCustomer();
                return Ok(allCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customerAccess.GetCustomerById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer value)
        {
            try
            {
                await _customerAccess.CreateCustomer(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Customer value)
        {
            try
            {
                await _customerAccess.UpdateCustomer(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _customerAccess.DeleteCustomer(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
