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
    public class ShoeController : ControllerBase
    {
        private readonly IShoeManager _manager;
        public ShoeController(IShoeManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [AllowAnonymous]
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

        [HttpGet("byName{name}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var model = await _manager.GetByName(name);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("category-count")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSizeOfCategory()
        {
                var list = await _manager.GetSizeOfCategory();
                return Ok(list);
        }

        [HttpGet("byCategory{category}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCategory([FromRoute] string category)
        {
            try
            {
                var models = await _manager.GetByCategory(category);
                return Ok(models);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("sorted")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSorted()
        {
            var list = await _manager.GetSorted();
            return Ok(list);
        }

        [HttpGet("with-offers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllWithOffers()
        {
            var list = await _manager.GetAllWithOffer();
            return Ok(list);
        }

        [HttpPost("create-shoe")]
        //[Authorize("Admin")]
        public async Task<IActionResult> CreateShoe([FromBody] ShoeModel shoe)
        {
            await _manager.CreateShoe(shoe);
            return Ok("Shoe added to the database.");
        }

        [HttpDelete("delete-shoe{id}")]
        //[Authorize("Admin")]
        public async Task<IActionResult> DeleteShoe([FromRoute] int id)
        {
            var response = await _manager.DeleteShoe(id);           
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The shoe has been deleted.");
        }

        [HttpPut("update-shoe")]
        //[Authorize("Admin")]
        public async Task<IActionResult> UpdateShoe([FromBody] ShoeModel model)
        {
            try
            {
                await _manager.UpdateShoe(model);
                return Ok("Changes made successfully");
            } catch (Exception)
            {
                return StatusCode(403);
            }
        }

    }
}
