using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DapperDataAccess.DataAccess.Concrete;
using Domain.Entities;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DpChoreController : ControllerBase
    {
        private readonly DpChoreRepository _choreRepository;

        public DpChoreController(DpChoreRepository choreRepository)
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

        [HttpPost]
        public async Task<IActionResult> CreateChore([FromBody] ChoreModel choreModel)
        {
            await _choreRepository.Create(choreModel);
            return Ok("Added.");
        }

    }
}
