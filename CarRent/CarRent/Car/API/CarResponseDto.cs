using System.Text.Json.Serialization;

namespace CarRent.Car.API
{
    public class CarResponseDto
    {
        public Guid Id { get; set; }

        public string CarNumber { get; set; }

        public string Brand { get; set; }

        public string CarClass { get; set; }

        public string Type { get; set; }

        public CarResponseDto(Domain.Car car)
        {
            Id = car.Id;
            CarNumber = car.CarNumber;
            Brand = car.Brand.Id.ToString();
            CarClass = car.CarClass.Id.ToString();
            Type = car.Type.Id.ToString();
        }

        public CarResponseDto() { }
    }
}
