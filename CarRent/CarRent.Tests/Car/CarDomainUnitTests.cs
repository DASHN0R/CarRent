using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarRent.Car.Domain;
using CarRent.Car.API;

namespace CarRent.Tests.Car
{
    public class CarDomainUnitTests
    {
        [Fact]
        public void CarConstructor_CreateCarBasedOnDto()
        {
            //Arrange
            var id = new Guid();
            var brandId = new Guid();
            var carClassId = new Guid();
            var carNumber = "1234567890";
            var typeId = new Guid();

            var expectedCar = new CarRent.Car.Domain.Car(id)
            {
                Brand = new Brand(brandId),
                CarClass = new CarClass(carClassId),
                CarNumber = carNumber,
                Type = new CarRent.Car.Domain.Type(typeId)
            };

            var carDto = new CarResponseDto()
            {
                Id = id,
                Brand = brandId.ToString(),
                CarClass = carClassId.ToString(),
                CarNumber = carNumber,
                Type = typeId.ToString()
            };

            //Act
            var createdCar = new CarRent.Car.Domain.Car(carDto);

            //Assert
            Assert.Equal(expectedCar, createdCar);
            Assert.Equal(expectedCar.Type.Id, createdCar.Type.Id);
            Assert.Equal(expectedCar.Brand.Id, createdCar.Brand.Id);
            Assert.Equal(expectedCar.CarClass.Id, createdCar.CarClass.Id);
            Assert.Equal(expectedCar.CarNumber, createdCar.CarNumber);

        }
    }
}
