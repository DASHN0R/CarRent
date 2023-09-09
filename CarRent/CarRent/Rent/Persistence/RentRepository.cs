using CarRent.Customer.Persistence;
using CarRent.Rent.Domain;

namespace CarRent.Rent.Persistence
{
    public class RentRepository : IRentRepository
    {
        private readonly RentContext _rentContext;

        public RentRepository(RentContext rentContext)
        {
            _rentContext = rentContext;
        }

        public void Add(Reservation reservation)
        {
            _rentContext.Reservations.Add(reservation);
            _rentContext.SaveChanges();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _rentContext.Reservations.ToList();
        }

        public Reservation GetById(Guid id)
        {
            var reservation = _rentContext.Reservations.Find(id);
            return reservation;
        }

        public void Remove(Reservation reservation)
        {
            _rentContext.Reservations.Remove(reservation);
            _rentContext.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            _rentContext.Reservations.Update(reservation);
            _rentContext.SaveChanges();
        }
    }
}
