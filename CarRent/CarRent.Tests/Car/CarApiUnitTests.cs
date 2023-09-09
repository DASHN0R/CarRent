using CarRent.Car.API;
using CarRent.Car.Domain;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.Tests.Car
{
    public class CarApiUnitTests
    {
        [Fact]
        public void CarDtoConstructor_CreateCarDtoBasedOnCar()
        {
            //Arrange
            var id = new Guid();
            var brandId = new Guid();
            var carClassId = new Guid();
            var carNumber = "1234567890";
            var typeId = new Guid();

            var car = new CarRent.Car.Domain.Car(id)
            {
                Brand = new Brand(brandId),
                CarClass = new CarClass(carClassId),
                CarNumber = carNumber,
                Type = new CarRent.Car.Domain.Type(typeId)
            };

            var expectedCarDto = new CarResponseDto()
            {
                Id = id,
                Brand = brandId.ToString(),
                CarClass = carClassId.ToString(),
                CarNumber = carNumber,
                Type = typeId.ToString()
            };

            //Act
            var createdCarDto = new CarResponseDto(car);

            //Assert
            Assert.Equal(expectedCarDto.Type, createdCarDto.Type);
            Assert.Equal(expectedCarDto.Brand, createdCarDto.Brand);
            Assert.Equal(expectedCarDto.CarClass, createdCarDto.CarClass);
            Assert.Equal(expectedCarDto.CarNumber, createdCarDto.CarNumber);

        }
    }
}
