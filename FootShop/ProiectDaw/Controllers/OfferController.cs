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
    public class OfferController : ControllerBase
    {
        private readonly IOfferManager _manager;
        public OfferController(IOfferManager manager)
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

        [HttpPost("create-offer")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateOffer([FromBody] OfferModel model)
        {
            await _manager.CreateOffer(model);
            return Ok("Offer added to the database.");
        }

        [HttpDelete("delete-offer{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteOffer([FromRoute] int id)
        {
            var response = await _manager.DeleteOffer(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The offer has been deleted.");
        }

        [HttpPut("update-offer")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateOffer([FromBody] OfferModel model)
        {
            try
            {
                await _manager.UpdateOffer(model);
                return Ok("Changes made successfully");
            }
            catch (Exception)
            {
                return StatusCode(403);
            }
        }



    }
 
}
