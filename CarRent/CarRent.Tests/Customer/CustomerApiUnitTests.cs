using CarRent.Customer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.Tests.Customer
{
    public class CustomerApiUnitTests
    {
        [Fact]
        public void CustomerDtoConstructor_CreateCustomerDtoBasedOnCustomer()
        {
            //Arrange
            var id = new Guid();
            var street = "Gaiserwaldstrasse 6";
            var city = "9015 St. Gallen";
            var firstName = "Dashnor";
            var lastName = "Shala";

            var customer = new CarRent.Customer.Domain.Customer(id)
            {
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            var expectedCustomerDto = new CustomerResponseDto()
            {
                Id = id,
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            //Act
            var createdCustomerDto = new CustomerResponseDto(customer);

            //Assert
            Assert.Equal(expectedCustomerDto.Street, createdCustomerDto.Street);
            Assert.Equal(expectedCustomerDto.FirstName, createdCustomerDto.FirstName);
            Assert.Equal(expectedCustomerDto.LastName, createdCustomerDto.LastName);
            Assert.Equal(expectedCustomerDto.City, createdCustomerDto.City);
        }
    }
}
