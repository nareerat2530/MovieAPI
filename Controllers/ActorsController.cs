using Microsoft.AspNetCore.Mvc;
using MovieProject.Interfaces;
using MovieProject.ViewModels;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfwork;
        private readonly IActorMapper _actorMapper;
        private readonly IActorViewModelMapper _actorViewModelMapper;


        public ActorsController(IUnitOfwork unitOfwork, IActorMapper actorMapper, IActorViewModelMapper actorViewModelMapper)
        {
            _unitOfwork = unitOfwork;
            _actorMapper = actorMapper;
            _actorViewModelMapper = actorViewModelMapper;

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddActor([FromBody] PostViewModel actor)
        {

            var _actor = _actorMapper.Map(actor);
            if (!await _unitOfwork.ActorRepository.AddNewActorAsync(_actor))
                return StatusCode(500, "Something went wrong!");
            if (!await _unitOfwork.Complete()) return StatusCode(500, "Something went wrong!");

            return StatusCode(201);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfwork.ActorRepository.GetActorById(id);



            if (result == null) return NotFound($"Could not find  actor with id: {id} in the system");
            var _actor = _actorViewModelMapper.Map(result);

            return Ok(_actor);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var actors = await _unitOfwork.ActorRepository.GetAllActorAsync();
            if (actors == null) return NotFound("Could not find any actor in the system");
            var _actors = _actorViewModelMapper.Map(actors);
            return Ok(_actors);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] PostViewModel actor)
        {
            var toUpdate = await _unitOfwork.ActorRepository.GetActorById(id);
            if (toUpdate == null) return NotFound($"id: {id } does not exist ");

            toUpdate = _actorMapper.Map(actor, toUpdate);

            if (_unitOfwork.ActorRepository.UpdateActor(toUpdate))
            {
                if (await _unitOfwork.Complete()) return NoContent();
            }
            return StatusCode(500, "Something went wrong");
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var toDelete = await _unitOfwork.ActorRepository.GetActorById(id);
            if (toDelete == null) return NotFound($"Cound not find any actor with id: {id}");

            if (!_unitOfwork.ActorRepository.RemoveActor(toDelete)) return StatusCode(500, "Something went wrong");
            if (await _unitOfwork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }






    }
}








