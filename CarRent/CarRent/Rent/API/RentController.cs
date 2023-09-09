using CarRent.Customer.API;
using CarRent.Customer.Domain;
using CarRent.Rent.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Rent.API
{
    [Route("API/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentRepository _repository;

        public RentController(IRentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<RentController>
        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _repository.GetAll();
            var reservationDtos = reservations.Select(r => new ReservationResponseDto(r));
            return Ok(reservationDtos);
        }

        // GET api/<RentController>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var reservation = _repository.GetById(new Guid(id));
            return Ok(reservation);
        }

        // POST api/<RentController>
        [HttpPost]
        public IActionResult Post([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Add(new Reservation(reservationResponseDto));
            return Ok();
        }

        // PUT api/<RentController>
        [HttpPut("{reservation}")]
        public void Put([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Update(new Reservation(reservationResponseDto));
        }

        // DELETE api/<RentController>
        [HttpDelete("{Customer}")]
        public void Delete([FromBody] ReservationResponseDto reservationResponseDto)
        {
            _repository.Remove(new Reservation(reservationResponseDto));
        }

        // PUT api/<RentController>
        [HttpPut("{createContract}")]
        public void Put([FromBody] ReservationResponseDto reservationResponseDto, DateTime pickUpDate, Guid carId)
        {
            var reservation = new Reservation(reservationResponseDto);
            reservation.CreateAndAssignContract(pickUpDate, new Car.Domain.Car(carId));
            _repository.Update(reservation);
        }
    }
}
