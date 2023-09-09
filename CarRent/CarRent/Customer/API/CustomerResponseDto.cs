namespace CarRent.Customer.API
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public CustomerResponseDto(Domain.Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Street = customer.Street;
            City = customer.City;
        }

        public CustomerResponseDto() { }
    }
}
