using System.Net;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAllChores()
        {
            return Ok(_choreDataAccess.GetAllChores().Result);
        }

        [HttpGet("getchoreswithuserid")]
        public IActionResult GetChoresAllUserId([FromQuery] UserModel model)
        {
            return Ok(_choreDataAccess.GetAllChoresForAUser(model).Result);
        }

        [HttpPost]
        public IActionResult CreateChore([FromBody] ChoreModel choreModel)
        {
            _choreDataAccess.CreateChoreModel(choreModel);
            return Ok("User added.");
        }

        [HttpPut]
        public IActionResult UpdateChore([FromBody] ChoreModel model)
        {
            _choreDataAccess.UpdateChoreModel(model);
            return Ok("Updated");
        }

        [HttpDelete]
        public IActionResult DeleteChore([FromBody] ChoreModel model)
        {
            _choreDataAccess.DeleteChoreModel(model);
            return Ok("Deleted");
        }

    }
}
