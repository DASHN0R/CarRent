using CarRent.Car.Domain;
using CarRent.Rent.API;
using CarRent.Rent.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.Tests.Rent
{
    public class RentApiUnitTests
    {
        [Fact]
        public void ReservationDtoConstructor_CreateReservationDtoBasedOnReservation()
        {
            //Arrange
            var id = new Guid();
            var durationInDays = 7;
            var carClassId = new Guid();
            var customerId = new Guid();
            var startDate = new DateTime(2023, 9, 9);
            var contractId = new Guid();

            var reservation = new Reservation(id)
            {
                DurationInDays = durationInDays,
                DesiredCarClass = new CarClass(carClassId),
                Customer = new CarRent.Customer.Domain.Customer(customerId),
                StartDate = startDate,
                Contract = new Contract(contractId),
            };

            var expectedReservation = new ReservationResponseDto()
            {
                Id = id,
                Customer = customerId,
                Contract = contractId,
                StartDate = startDate,
                DurationInDays = durationInDays,
                DesiredCarClass = carClassId
            };

            //Act
            var createdReservation = new ReservationResponseDto(reservation);

            //Assert
            Assert.Equal(expectedReservation.Customer, createdReservation.Customer);
            Assert.Equal(expectedReservation.Contract, createdReservation.Contract);
            Assert.Equal(expectedReservation.StartDate, createdReservation.StartDate);
            Assert.Equal(expectedReservation.DurationInDays, createdReservation.DurationInDays);
            Assert.Equal(expectedReservation.DesiredCarClass, createdReservation.DesiredCarClass);
        }
    }
}
