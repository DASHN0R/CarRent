using CarRent.Common.Domain;

namespace CarRent.Rent.Domain
{
    public class Contract : Entity
    {
        public Contract(Guid id, DateTime pickUpDate, Car.Domain.Car car) : base(id)
        {
            PickUpDate = pickUpDate;
            Car = car;
        }

        public Car.Domain.Car Car { get; set; }

        public Contract(Guid id) : base(id)
        {
        }

        public DateTime PickUpDate { get; set; }
    }
}
