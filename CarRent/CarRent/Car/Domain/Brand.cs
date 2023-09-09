using CarRent.Common.Domain;

namespace CarRent.Car.Domain
{
    public class Brand : Entity
    {
        public Brand(Guid id) : base(id)
        {
        }

        public string Name { get; }

    }
}
