using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution09Partie2.Models;
using Solution09Partie2.Services;

namespace Solution09Partie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }


        [HttpPost]
        public IActionResult AddNewOrder([FromBody][Bind("CustomerId,ProductId,OrderDate,OrderQuantity")] TblOrder order)
        {
            if (ModelState.IsValid)
            {
                var newOrder =  ordersRepository.AddNewOrder(order);
                if (newOrder != null)
                    return Ok(newOrder);
                else
                    return BadRequest();
            }
            return BadRequest();

        }



        [HttpGet("customer/{id}")]
        public IActionResult GetAllOrdersFor([FromRoute] int id)
        {
            var orders = ordersRepository.GetAllOrdersFor(id);
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }

    }
}
