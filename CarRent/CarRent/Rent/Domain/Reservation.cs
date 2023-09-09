using CarRent.Car.Domain;
using CarRent.Common.Domain;
using CarRent.Rent.API;

namespace CarRent.Rent.Domain
{
    public class Reservation : Entity, IAggregateRoot
    {
        public Reservation(Guid id) : base(id)
        {

        }

        public int DurationInDays { get; set; }

        public CarClass? DesiredCarClass { get; set; }
        public Customer.Domain.Customer Customer { get; set; }

        public DateTime StartDate { get; set; }

        public Contract? Contract { get; set; }

        public decimal Total
        {
            get
            {
                if (DesiredCarClass is null)
                {
                    return 0;
                }

                return DurationInDays * DesiredCarClass.DailyFee;
            }
        }

        public void CreateAndAssignContract(DateTime pickUpDateTime, Car.Domain.Car car)
        {
            Contract = new Contract(new Guid(), pickUpDateTime, car);
        }

        public Reservation(ReservationResponseDto reservation) : base(reservation.Id)
        {
            DurationInDays = reservation.DurationInDays;
            DesiredCarClass = new CarClass(reservation.DesiredCarClass);
            Customer = new Customer.Domain.Customer(reservation.Customer);
            StartDate = reservation.StartDate;
            Contract = new Contract(reservation.Contract);
        }
    }
}
