using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Entities;
using EfDataAccess.DataAccess.Concrete;

namespace MongoDb.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EfUserController : ControllerBase
    {

        private readonly EfUserRepository _userRepository;

        public EfUserController(EfUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var watch = Stopwatch.StartNew();
            var users = await _userRepository.GetAll();
            watch.Stop();
            

            Console.WriteLine($"Entity Framework : {watch.Elapsed.TotalMilliseconds}");

            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var watch = Stopwatch.StartNew();

            var user = await _userRepository.GetById(id);

            watch.Stop();

            Console.WriteLine($"Entity Framework : {watch.Elapsed.TotalMilliseconds}");
            return Ok(user);
        }
        [HttpGet("searchfirstname")]
        public  IActionResult SearchFirstName([FromQuery ]string firstname)
        {
            var watch = Stopwatch.StartNew();

            var users =  _userRepository.SearchFirstName(firstname);

            watch.Stop();

            Console.WriteLine($"Entity Framework : {watch.Elapsed.TotalMilliseconds}");
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
