using CarRent.Common.Domain;

namespace CarRent.Car.Domain
{
    public class CarClass : Entity
    {
        public string Name { get; }

        public CarClass(Guid id) : base(id)
        {

        }

        public decimal DailyFee { get; set; }
    }
}
