using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.BLL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _manager;
        public OrderController(IOrderManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Get()
        {
            var orders = await _manager.GetAll();
            return Ok(orders);
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel model)
        {
            await _manager.CreateOrder(model);
            return Ok();
        }

        [HttpDelete("delete-order{id}")]
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var response = await _manager.DeleteOrder(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The order has been deleted.");
        }

        [HttpPut("update-order")]
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderModel model)
        {
            try
            {
               await _manager.UpdateOrder(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
