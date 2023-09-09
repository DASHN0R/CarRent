using CarRent.Customer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Customer.API
{
    [Route("API/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _repository.GetAll();
            var customerDtos = customers.Select(c => new CustomerResponseDto(c));
            return Ok(customerDtos);
        }

        // GET api/<CustomerController>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var customer = _repository.GetById(new Guid(id));
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerResponseDto CustomerResponseDto)
        {
            _repository.Add(new Domain.Customer(CustomerResponseDto));
            return Ok();
        }

        // PUT api/<CustomerController>
        [HttpPut("{Customer}")]
        public void Put([FromBody] CustomerResponseDto CustomerResponseDto)
        {
            _repository.Update(new Domain.Customer(CustomerResponseDto));
        }

        // DELETE api/<CustomerController>
        [HttpDelete("{Customer}")]
        public void Delete([FromBody] CustomerResponseDto CustomerResponseDto)
        {
            _repository.Remove(new Domain.Customer(CustomerResponseDto));
        }
    }
}
