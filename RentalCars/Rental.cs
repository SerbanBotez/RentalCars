namespace RentalCars
{
    public class Rental
    {

        public Rental(int id, Customer customer, Car car, int daysRented)
        {
            Id = id;
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
        }

        public int Id { get; }
        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }
    }
}