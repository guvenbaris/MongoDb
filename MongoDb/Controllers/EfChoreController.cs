using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using EfDataAccess.DataAccess.Concrete;

namespace MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfChoreController : ControllerBase
    {

        private readonly EfChoreRepository _choreRepository;

        public EfChoreController(EfChoreRepository choreRepository)
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
