using Microsoft.AspNetCore.Mvc;
using MongoDb.DataOperation;

namespace MongoDb.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreRepository _genreRepository;

        public GenreController(GenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _genreRepository.GetAll().Result;

            return Ok(result);
        }

    }
}
