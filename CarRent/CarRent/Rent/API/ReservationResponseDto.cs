using CarRent.Rent.Domain;

namespace CarRent.Rent.API
{
    public class ReservationResponseDto
    {
        public Guid Id { get; set; }

        public Guid Customer { get; set; }

        public Guid Contract { get; set; }

        public decimal Total { get; set; }

        public DateTime StartDate { get; set; }

        public int DurationInDays { get; set; }

        public Guid DesiredCarClass { get; set; }

        public ReservationResponseDto(Reservation reservation)
        {
            Id = reservation.Id;
            Customer = reservation.Customer.Id;
            Contract = reservation.Contract.Id;
            Total = reservation.Total;
            DurationInDays = reservation.DurationInDays;
            DesiredCarClass = reservation.DesiredCarClass.Id;
            StartDate = reservation.StartDate;
        }

        public ReservationResponseDto() { }
    }
}
