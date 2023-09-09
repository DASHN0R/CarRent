using CarRent.Common.Domain;
using CarRent.Customer.API;

namespace CarRent.Customer.Domain
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id) : base(id) { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public Customer(CustomerResponseDto customerResponseDto) : base(customerResponseDto.Id)
        {
            FirstName = customerResponseDto.FirstName;
            LastName = customerResponseDto.LastName;
            Street = customerResponseDto.Street;
            City = customerResponseDto.City;
        }
    }
}
