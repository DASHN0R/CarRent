using CarRent.Car.Domain;
using CarRent.Customer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.Tests.Customer
{
    public class CustomerDomainUnitTests
    {
        [Fact]
        public void CustomerConstructor_CreateCustomerBasedOnDto()
        {
            //Arrange
            var id = new Guid();
            var street = "Gaiserwaldstrasse 6";
            var city = "9015 St. Gallen";
            var firstName = "Dashnor";
            var lastName = "Shala";

            var expectedCustomer = new CarRent.Customer.Domain.Customer(id)
            {
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            var customerDto = new CustomerResponseDto()
            {
                Id = id,
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            //Act
            var createdCustomer = new CarRent.Customer.Domain.Customer(customerDto);

            //Assert
            Assert.Equal(expectedCustomer, createdCustomer);
            Assert.Equal(expectedCustomer.Street, createdCustomer.Street);
            Assert.Equal(expectedCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(expectedCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(expectedCustomer.City, createdCustomer.City);
        }
    }
}
