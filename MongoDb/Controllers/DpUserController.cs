using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DapperDataAccess.DataAccess.Concrete;
using Domain.Entities;

namespace MongoDb.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class DpUserController : ControllerBase
    {
        private readonly DpUserRepository _userRepository;

        public DpUserController(DpUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var users = await _userRepository.GetAll();
            watch.Stop();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var watch = Stopwatch.StartNew();

            var user = await _userRepository.GetById(id);

            watch.Stop();

            Console.WriteLine($"Dapper : {watch.Elapsed.TotalMilliseconds}");
            return Ok(user);
        }

        [HttpGet("searchfirstname")]
        public async Task<IActionResult> SearchFirstName([FromQuery] string firstname)
        {
            var watch = Stopwatch.StartNew();

            var users = await _userRepository.SearchFirstName(firstname);

            watch.Stop();

            Console.WriteLine($"Dapper : {watch.Elapsed.TotalMilliseconds}");
            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel model)
        {
            await _userRepository.Create(model);
            return Ok();
        }
    }
}
