using CarRent.Car.API;
using CarRent.Common.Domain;

namespace CarRent.Car.Domain
{
    public class Car : Entity, IAggregateRoot
    {
        public Car(Guid id) : base(id)
        {

        }

        public string CarNumber { get; set; }

        public Brand Brand { get; set; }

        public Type Type { get; set; }

        public CarClass CarClass { get; set; }

        public Car(CarResponseDto carResponseDto) : base(carResponseDto.Id)
        {
            CarNumber = carResponseDto.CarNumber;
            Brand = new Brand(new Guid(carResponseDto.Brand));
            Type = new Type(new Guid(carResponseDto.Type));
            CarClass = new CarClass(new Guid(carResponseDto.CarClass));
        }

    }
}
