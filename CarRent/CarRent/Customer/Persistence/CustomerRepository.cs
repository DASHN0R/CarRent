using CarRent.Car.Persistence;
using CarRent.Customer.Domain;

namespace CarRent.Customer.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }

        public void Add(Domain.Customer car)
        {
            _customerContext.Customers.Add(car);
            _customerContext.SaveChanges();
        }

        public IEnumerable<Domain.Customer> GetAll()
        {
            return _customerContext.Customers.ToList();
        }

        public Domain.Customer GetById(Guid id)
        {
            var car = _customerContext.Customers.Find(id);
            return car;
        }

        public void Remove(Domain.Customer customer)
        {
            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }

        public void Update(Domain.Customer customer)
        {
            _customerContext.Customers.Update(customer);
            _customerContext.SaveChanges();
        }
    }
}
