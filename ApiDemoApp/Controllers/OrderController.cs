using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IFoodData _fooData;
        private readonly IOrderData _orderData;

        public OrderController(IFoodData fooData , IOrderData orderData)
        {
            _fooData = fooData;
            _orderData = orderData;
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(OrderModel order)
        {
            var food = await _fooData.GetFood();

            order.Total = order.Quantity * food.Where(x => x.Id == order.FoodId).First().Price;

            int id = await _orderData.CreateOrder(order);
            
            return Ok(new { Id = id});
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var order = await _orderData.GetOrderById(id);

            if (order != null)
            {
                var food = await _fooData.GetFood();
                var outPut = new
                {
                    Order = order,
                    ItemPurchased = food.FirstOrDefault(x => x.Id == order.FoodId)?.Title
                };
                return Ok(outPut);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
