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
    public class ShoeOrderController : ControllerBase
    {
        private readonly IShoeOrderManager _manager;
        public ShoeOrderController(IShoeOrderManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> Get()
        {
            var objs = await _manager.GetAll();
            return Ok(objs);
        }

        [HttpGet("get-list{id}")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> GetListOfItems([FromRoute] int id)
        {
            try
            {
                var shoes = _manager.GetOrderItems(id);
                return Ok(shoes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("create-shoeOrder")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> CreateShoe([FromBody] ShoeOrderModel model)
        {
            await _manager.CreateShoeOrder(model);
            return Ok("Object added to the database.");
        }

        [HttpDelete("delete-shoeOrder{id}")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> DeleteShoeOrder([FromRoute] int id)
        {
            var response = await _manager.DeleteShoeOrder(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The object has been deleted.");
        }

        [HttpPut("update-shoeOrder")]
        [Authorize("Customer, Admin")]
        public async Task<IActionResult> UpdateShoe([FromBody] ShoeOrderModel model)
        {
            try
            {
                await _manager.UpdateShoeOrder(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
