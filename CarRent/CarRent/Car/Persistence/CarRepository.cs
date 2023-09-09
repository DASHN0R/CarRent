using CarRent.Car.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Car.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _carContext;

        public CarRepository(CarContext carContext)
        {
            _carContext = carContext;
        }

        public void Add(Domain.Car car)
        {
            _carContext.Cars.Add(car);
            _carContext.SaveChanges();
        }

        public void Remove(Domain.Car car)
        {
            _carContext.Cars.Remove(car);
            _carContext.SaveChanges();
        }

        public void Update(Domain.Car car)
        {
            _carContext.Cars.Update(car);
            _carContext.SaveChanges();
        }

        public IEnumerable<Domain.Car> GetAll()
        {
            return _carContext.Cars.ToList();
        }

        public Domain.Car GetByCarNumber(string carNumber)
        {
            var car = _carContext.Cars.First(x => x.CarNumber == carNumber);
            return car;
        }

        public Domain.Car GetById(Guid id)
        {
            var car = _carContext.Cars.Find(id);
            return car;
        }
    }
}
