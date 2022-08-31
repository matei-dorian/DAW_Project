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
    public class ShoeSizeController : ControllerBase
    {
        private readonly IShoeSizeManager _manager;
        public ShoeSizeController(IShoeSizeManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> Get()
        {
            var shoeSizes = await _manager.GetAll();
            return Ok(shoeSizes);
        }

        [HttpGet("byId{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var models = await _manager.GetWithShoeId(id);
                return Ok(models);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("create-shoeSize")]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateShoe([FromBody] ShoeSizeModel shoeSize)
        {
            await _manager.CreateShoeSize(shoeSize);
            return Ok("ShoeSize added to the database.");
        }

        [HttpDelete("delete-shoeSize{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteShoeSize([FromRoute] int id)
        {
            var response = await _manager.DeleteShoeSize(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The shoeSize has been deleted.");
        }

        [HttpPut("update-shoeSize")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateShoeSize([FromBody] ShoeSizeModel model)
        {
            try
            {
                await _manager.UpdateShoeSize(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }
    }
}
