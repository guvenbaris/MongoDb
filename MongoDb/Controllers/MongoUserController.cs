using System;
using System.Diagnostics;
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
            var watch = Stopwatch.StartNew();
            var users = await _userRepository.GetAll();
            watch.Stop();


            Console.WriteLine($"Mongo : {watch.Elapsed.TotalMilliseconds}");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var watch = Stopwatch.StartNew();

            var user = await _userRepository.GetById(id);

            watch.Stop();

            Console.WriteLine($"Mongo : {watch.Elapsed.TotalMilliseconds}");
            return Ok(user);
        }
        [HttpGet("searchfirstname")]
        public async Task<IActionResult> SearchFirstName([FromQuery] string firstname)
        {
            var watch = Stopwatch.StartNew();

            var users = await _userRepository.SearchFirstName(firstname);

            watch.Stop();

            Console.WriteLine($"Mongo : {watch.Elapsed.TotalMilliseconds}");
            return Ok(users);
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
