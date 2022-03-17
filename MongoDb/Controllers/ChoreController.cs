using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private readonly ChoreDataAccess _choreDataAccess;

        public ChoreController(ChoreDataAccess choreDataAccess)
        {
            _choreDataAccess = choreDataAccess;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel userModel)
        {
            _choreDataAccess.CreateUser(userModel);
            return Ok("User added.");
        }

    }
}
