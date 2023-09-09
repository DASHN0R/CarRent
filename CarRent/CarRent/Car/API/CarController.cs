using Microsoft.AspNetCore.Mvc;
using CarRent.Car.Persistence;


namespace CarRent.Car.API
{
    using CarRent.Car.Domain;

    using Microsoft.AspNetCore.Mvc;

    [Route("API/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get()
        {
            var cars = _repository.GetAll();
            var carDtos = cars.Select(c => new CarResponseDto(c));
            return Ok(carDtos);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var car = _repository.GetById(new Guid(id));
            return Ok(car);
        }

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] CarResponseDto carResponseDto)
        {
            _repository.Add(new Car(carResponseDto));
            return Ok();
        }

        // PUT api/<CarController>
        [HttpPut("{car}")]
        public void Put([FromBody] CarResponseDto carResponseDto)
        {
            _repository.Update(new Car(carResponseDto));
        }

        // DELETE api/<CarController>
        [HttpDelete("{car}")]
        public void Delete([FromBody] CarResponseDto carResponseDto)
        {
            _repository.Remove(new Car(carResponseDto));
        }
    }
}
