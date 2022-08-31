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
    public class DescriptionController : ControllerBase
    {
        private readonly IDescriptionManager _manager;
        public DescriptionController(IDescriptionManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Get()
        {
            var shoes = await _manager.GetAll();
            return Ok(shoes);
        }

        [HttpGet("byId{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = await _manager.GetById(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost("create-description")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateDescription([FromBody] DescriptionModel model)
        {
            await _manager.CreateDescription(model);
            return Ok("Description added to the database.");
        }

        [HttpDelete("delete-description{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteDescription([FromRoute] int id)
        {
            var response = await _manager.DeleteDescription(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The offer has been deleted.");
        }

        [HttpPut("update-Description")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateDescription([FromBody] DescriptionModel model)
        {
            try
            {
                await _manager.UpdateDescription(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }



    }
}
