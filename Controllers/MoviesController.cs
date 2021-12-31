using Microsoft.AspNetCore.Mvc;
using MovieProject.Interfaces;
using MovieProject.Interfaces.IMapper;
using MovieProject.Models;
using MovieProject.ViewModels.Actor.ActorMovie;
using MovieProject.ViewModels.Movie;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        private readonly IMovieMapper _movieMapper;
        private readonly IMovieViewModelMapper _movieViewModelMapper;
        public MoviesController(IUnitOfwork unitOfwork, IMovieMapper movieMapper, IMovieViewModelMapper movieViewModelMapper)
        {
            _unitOfWork = unitOfwork;
            _movieMapper = movieMapper;
            _movieViewModelMapper = movieViewModelMapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _unitOfWork.MovieRepository.GetAllMovieAsync();

            if (movies == null) return NotFound("Could not find any movie in the system");
            var _movies = _movieViewModelMapper.Map(movies);
            return Ok(_movies);
        }

        [HttpPost("add-actor-to-movie")]
        public async Task<IActionResult> AddActorToMovie(int actorId, int movieId)
        {
            var actor = await _unitOfWork.ActorRepository.GetActorById(actorId);
            var movie = await _unitOfWork.MovieRepository.GetMoiveByIdAsync(movieId);
            if (actor != null && movie != null)
            {

                var addNewActorMovie = await _unitOfWork.ActorMovieRepository.CheckIfActorWithMovieExist(movieId, actorId);

                if (addNewActorMovie != null)
                {
                    return StatusCode(500, "The movie Already Added to movie!");
                }
                addNewActorMovie = new ActorMovie()
                {

                    ActorId = actorId,
                    MovieId = movieId
                };
                if (await _unitOfWork.ActorMovieRepository.AddNewActorToMovie(addNewActorMovie))

                    if (!await _unitOfWork.Complete()) return StatusCode(500, "Something went wrong!");
                return StatusCode(201);
            }
            return StatusCode(500, "Movie or actor does not exist");

        }


        [HttpPost("add")]
        public async Task<IActionResult> AddMovie([FromBody] PostMovieViewModel movie)
        {

            var addMovie = _movieMapper.Map(movie);
            if (await _unitOfWork.MovieRepository.AddNewMoiveAsync(addMovie))
            {
                if (!await _unitOfWork.Complete()) return StatusCode(500, "Something went wrong!");
                return StatusCode(201);
            }
            return StatusCode(500, "Something went wrong!");
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var result = await _unitOfWork.MovieRepository.GetMoiveByIdAsync(id);
            if (result == null) return NotFound($"Could not find  movie with id: {id} in the system");
            var _movie = _movieViewModelMapper.Map(result);
            if (_movie == null)
            {
                return StatusCode(500,"Something went wrong");
            }
            return Ok(_movie);
        }

        [HttpGet("get-movie-by-actorid/{id}")]
        public async Task<IActionResult> GetMovieByActorId(int id)
        {
            var result = await _unitOfWork.MovieRepository.GetMoviesByActorIdAsync(id);
            if (result == null) return NotFound($"Could not find  movie with id: {id} in the system");
            var _movie = _movieViewModelMapper.Map(result);
            return Ok(_movie);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieViewmodel movie)
        {
            var toUpdate = await _unitOfWork.MovieRepository.GetMoiveByIdAsync(id);
            if (toUpdate == null) return NotFound($"Cound not find any movie with id: {id}");
            toUpdate = _movieMapper.Map(movie, toUpdate);

            if (_unitOfWork.MovieRepository.UpdateMovie(toUpdate))
            {
                if (await _unitOfWork.Complete()) return NoContent();
            }
            return StatusCode(500, "Something went wrong");
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var toDelete = await _unitOfWork.MovieRepository.GetMoiveByIdAsync(id);
            if (toDelete == null) return NotFound($"Cound not find any car with id: {id}");

            if (_unitOfWork.MovieRepository.RemoveMovie(toDelete))
                if (await _unitOfWork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }




    }
}
