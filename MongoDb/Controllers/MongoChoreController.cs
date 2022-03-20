using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDataAccess.DataAccess.Concrete;


namespace MongoDb.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MongoChoreController : ControllerBase
    {
        private readonly MongoChoreRepository _choreRepository;

        public MongoChoreController(MongoChoreRepository choreRepository)
        {
            _choreRepository = choreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChores()
        {
            return Ok(await _choreRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            return Ok(await _choreRepository.GetById(id));
        }

        [HttpGet("getchoreswithuserid")]
        public async Task<IActionResult> GetChoresAllUserId( UserModel model)
        {
            return Ok( await _choreRepository.GetAllChoresForAUser(model));
        }

        [HttpPost]
        public async Task<IActionResult> CreateChore([FromBody] ChoreModel choreModel)
        {
            await _choreRepository.Create(choreModel);
            return Ok("Added.");
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateChore([FromBody] ChoreModel model)
        //{
        //   await _choreRepository.Update(model);
        //    return Ok("Updated");
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteChore([FromBody] ChoreModel model)
        //{
        //    await _choreRepository.Delete(model);
        //    return Ok("Deleted");
        //}

    }
}
