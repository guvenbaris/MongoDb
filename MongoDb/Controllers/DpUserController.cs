using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDataAccess.DataAccess.Concrete;
using Domain.Entities;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
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
    }
}
