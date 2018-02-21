using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BASTA_dynamics_Userlib_db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Table;

namespace BastaCRM.CustomerService.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICosmosConnector _customerAccess;

        public CustomerController(ICosmosConnector customerAccess)
        {
            _customerAccess = customerAccess;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allCustomers = await _customerAccess.GetEmployee("");
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
                var customer = await _customerAccess.GetEmployee(id.ToString());
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BASTA_dynamics_Userlib_db.EmployeeObject value)
        {
            try
            {
                await _customerAccess.SetEmployee(value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]EmployeeObject value)
        {
            try
            {
                await _customerAccess.SetEmployee(value);
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
                await _customerAccess.DelEmployee(id.ToString());
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
