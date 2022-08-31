using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDaw.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _manager;
        public UserController(IUserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Authorize("Admin")]
        public async Task<IActionResult> Get()
        {
            var shoes = await _manager.GetAll();
            return Ok(shoes);
        }

        [HttpDelete("delete-user{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteDescription([FromRoute] int id)
        {
            var response = await _manager.DeleteUser(id);
            if (response == -1)
                return Ok("The requested id is not in the database.");

            return Ok("The offer has been deleted.");
        }
    }
}
