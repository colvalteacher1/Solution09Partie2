using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Dtos;
using Solution09Partie2.Models;
using Solution09Partie2.Services;

namespace Solution09Partie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository customersRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        [HttpGet("all")]
        public IActionResult GetCustomers()
        {
            return Ok(customersRepository.GetAll());
        }

        [HttpGet("one/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = customersRepository.GetById(id);
            if (customer == null)
                return NotFound($"Client avec l'id {id} introuvable");
            CustomerDto customerDto = new CustomerDto()
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                City = customer.City,
                CreationDate = customer.CreationDate
            };
            return Ok(customerDto);
        }

        // POST: api/TblCustomer
        [HttpPost]
        public ActionResult PostTblCustomer([FromBody] TblCustomer tblcustomer)
        {
            var newCustomer = customersRepository.Add(tblcustomer);

            return Created($"GET: /api/customers/one/{newCustomer.CustomerId }", newCustomer);
        }

        // PUT: api/TblCustomer/{id}
        [HttpPut("{id}")]
        public ActionResult PutTblCustomer([FromRoute] int id, [FromBody] TblCustomer tblcustomer)
        {
            if(customersRepository.GetById(id) == null)
                return NotFound($"Client avec l'id {id} introuvable");
       
           tblcustomer.CustomerId = id;
           var updateCustomer = customersRepository.Update(tblcustomer);

            return Ok(updateCustomer);
        }


    }
}
