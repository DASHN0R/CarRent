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
    public class RentDomainUnitTests
    {
        [Fact]
        public void ReservationConstructor_CreateReservationBasedOnDto()
        {
            //Arrange
            var id = new Guid();
            var durationInDays = 7;
            var carClassId = new Guid();
            var customerId = new Guid();
            var startDate = new DateTime(2023, 9, 9);
            var contractId = new Guid();

            var expectedReservation = new Reservation(id)
            {
                DurationInDays = durationInDays,
                DesiredCarClass = new CarClass(carClassId),
                Customer = new CarRent.Customer.Domain.Customer(customerId),
                StartDate = startDate,
                Contract = new Contract(contractId),
            };

            var reservationDto = new ReservationResponseDto()
            {
                Id = id,
                Customer = customerId,
                Contract = contractId,
                StartDate = startDate,
                DurationInDays = durationInDays,
                DesiredCarClass = carClassId
            };

            //Act
            var createdReservation = new Reservation(reservationDto);

            //Assert
            Assert.Equal(expectedReservation, createdReservation);
            Assert.Equal(expectedReservation.Customer.Id, createdReservation.Customer.Id);
            Assert.Equal(expectedReservation.Contract.Id, createdReservation.Contract.Id);
            Assert.Equal(expectedReservation.StartDate, createdReservation.StartDate);
            Assert.Equal(expectedReservation.DurationInDays, createdReservation.DurationInDays);
            Assert.Equal(expectedReservation.DesiredCarClass, createdReservation.DesiredCarClass);
        }

        [Fact]
        public void Reservation_CalculateTotal_ReturnsTotal()
        {
            //Arrange
            var reservation = new Reservation(new Guid())
            {
                DurationInDays = 7,
                DesiredCarClass = new CarClass(new Guid())
                {
                    DailyFee = 69
                }
            };

            var expectedResult = 7 * 69;

            //Act
            var result = reservation.Total;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Reservation_CalculateTotalButNoCarClass_ReturnsZero()
        {
            //Arrange
            var reservation = new Reservation(new Guid())
            {
                DurationInDays = 7,
            };

            var expectedResult = 0;

            //Act
            var result = reservation.Total;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
