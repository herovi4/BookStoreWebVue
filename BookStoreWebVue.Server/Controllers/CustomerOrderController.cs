﻿using BookStore;
using Microsoft.AspNetCore.Mvc;
using TestOperations;

namespace BookStoreWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerOrderController : Controller
    {
        private readonly CustomerOrderDataAccess _customerOrderDataAccess;

        public CustomerOrderController(CustomerOrderDataAccess customerOrderDataAccess)
        {
            _customerOrderDataAccess = customerOrderDataAccess;
        }
        // GET: api/author
        [HttpGet]
        public IActionResult Get()
        {
            var allcustomerAddresses = _customerOrderDataAccess.GetCustomerOrders();
            return Ok(allcustomerAddresses);
        }

        // GET: api/author/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, int addId)
        {
            var customerAddress = _customerOrderDataAccess.GetCustomerOrderById(id);

            if (customerAddress == null)
            {
                return NotFound();
            }

            return Ok(customerAddress);
        }

        // POST: api/author
        [HttpPost("post")]
        public IActionResult Post([FromBody] CustomerOrder customerOrder)
        {
            if (customerOrder == null)
            {
                return BadRequest();
            }

            _customerOrderDataAccess.AddCustomerOrder(customerOrder);
            return CreatedAtAction(nameof(Get), new { id = customerOrder.customerId }, customerOrder);
        }

        [HttpPut("{id}/update")]
        public IActionResult Put(int id, [FromBody] CustomerOrder customerOrder)
        {
            if (customerOrder == null || customerOrder.customerId != id)
            {
                return BadRequest();
            }

            var existingCustomer = _customerOrderDataAccess.GetCustomerOrderById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerOrderDataAccess.UpdateCustomerOrder(customerOrder);
            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var customer = _customerOrderDataAccess.GetCustomerOrderById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerOrderDataAccess.DeleteCustomerOrder(id);
            return NoContent();
        }
    }
}
