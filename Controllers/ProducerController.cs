using Microsoft.AspNetCore.Mvc;
using MovieProject.Interfaces;
using MovieProject.Interfaces.IMapper;
using MovieProject.ViewModels.Producer;
using System.Reflection;
using System.Threading.Tasks;

namespace MovieProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IUnitOfwork _unitOfWork;
        private readonly IProducerMapper _producerMapper;
        private readonly IProducerViewModelMapper _producerViewModelMapper;



        public ProducerController(IUnitOfwork unitOfwork, IProducerMapper producerMapper, IProducerViewModelMapper producerViewModelMapper)
        {
            _unitOfWork = unitOfwork;
            _producerMapper = producerMapper;
            _producerViewModelMapper = producerViewModelMapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var producer = await _unitOfWork.ProducerRerository.GetAllProducerAsync();
            if (producer == null) return NotFound("Could not find any producer in the system");
            var _producer = _producerViewModelMapper.Map(producer);
            return Ok(_producer);
        }
        bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProducer([FromBody] PostProducerViewModel producer)
        {
           
            var addProducer = _producerMapper.Map(producer);
            if (IsAnyNullOrEmpty(producer)) return StatusCode(500);
           
            if (await _unitOfWork.ProducerRerository.AddNewProducerAsync(addProducer))
            {
                if (!await _unitOfWork.Complete()) return StatusCode(500, "Something went wrong!");

                return StatusCode(201);
            }
            return StatusCode(500, "Something went wrong!");
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _unitOfWork.ProducerRerository.GetProducerById(id);
            if (result == null) return NotFound($"Could not find  producer with id: {id} in the system");
            var _producer = _producerViewModelMapper.Map(result);
            return Ok(_producer);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProducer(int id, [FromBody] PostProducerViewModel producer)
        {
            var toUpdate = await _unitOfWork.ProducerRerository.GetProducerById(id);
            if (toUpdate == null) return NotFound($"Cound not find any producer with id: {id}");

            toUpdate = _producerMapper.Map(producer, toUpdate);

            if (_unitOfWork.ProducerRerository.UpdateProducer(toUpdate))
            {
                if (await _unitOfWork.Complete()) return NoContent();
            }
            return StatusCode(500, "Something went wrong");
        }
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var toDelete = await _unitOfWork.ProducerRerository.GetProducerById(id);
            if (toDelete == null) return NotFound($"Cound not find any prodcuer with id: {id}");

            if (_unitOfWork.ProducerRerository.RemoveProducer(toDelete))
                if (await _unitOfWork.Complete()) return NoContent();
            return StatusCode(500, "Something went wrong");
        }



    }
}
