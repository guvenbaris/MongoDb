using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDataAccess.DataAccess.Concrete;

namespace MongoDb.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MongoUserController : ControllerBase
    {
        private readonly MongoUserRepository _userRepository;

        public MongoUserController(MongoUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _userRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel model)
        {
            await _userRepository.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            await _userRepository.Update(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] UserModel model)
        {
            await _userRepository.Delete(model);
            return Ok();
        }
    }
}
