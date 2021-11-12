using Microsoft.AspNetCore.Mvc;
using MovieProject.Interfaces;
using MovieProject.Interfaces.IMapper;
using MovieProject.ViewModels.Cinema;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfwork;
        private readonly ICinemaMapper _cinemaMapper;
        private readonly ICinemaViewModelMapper _cinemaViewModelMapper;


        public CinemaController(IUnitOfwork unitOfwork, ICinemaViewModelMapper cinemaViewModelMapper, ICinemaMapper cinemaMapper)
        {
            _unitOfwork = unitOfwork;
            _cinemaViewModelMapper = cinemaViewModelMapper;
            _cinemaMapper = cinemaMapper;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cinema = await _unitOfwork.CinemaRepository.GetAllCinemaAsync();
            if (cinema == null) return NotFound("Could not find any actor in the system");
            var _cinema = _cinemaViewModelMapper.Map(cinema);
            return Ok(_cinema);
        }
        [HttpPost("add-cinema")]
        public async Task<IActionResult> AddNewCinema([FromBody] PostCinemaViewModel cinema)
        {
            var addCinema = _cinemaMapper.Map(cinema);

            if (await _unitOfwork.CinemaRepository.AddNewCinemaAsync(addCinema))
            {
                if (!await _unitOfwork.Complete()) return StatusCode(500, "Something went wrong!");

                return StatusCode(201);
            }
            return StatusCode(500, "Something went wrong!");
        }
        [HttpGet("get-cinema-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfwork.CinemaRepository.GetCinemaByIdAsync(id);
            if (result == null) return NotFound($"Could not find cinema with id: {id} in the system");
            var _cinema = _cinemaViewModelMapper.Map(result);
            return Ok(_cinema);
        }
        [HttpPut("update-cinema-by-id/{id}")]
        public async Task<IActionResult> UpdateCinema(int id, [FromBody] PostCinemaViewModel cinema)
        {
            var toUpdate = await _unitOfwork.CinemaRepository.GetCinemaByIdAsync(id);
            if (toUpdate == null) return NotFound($"Cound not find any cinema with id: {id}");



            toUpdate = _cinemaMapper.Map(cinema, toUpdate);
            if (_unitOfwork.CinemaRepository.UpdateCinema(toUpdate))
            {
                if (await _unitOfwork.Complete()) return NoContent();
            }
            return StatusCode(500, "Something went wrong");
        }
        [HttpDelete("remove-cinema/{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var toDelete = await _unitOfwork.CinemaRepository.GetCinemaByIdAsync(id);
            if (toDelete == null) return NotFound($"Cound not find any actor with id: {id}");

            if (_unitOfwork.CinemaRepository.RemoveCinema(toDelete))
                if (await _unitOfwork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }
    }
}
