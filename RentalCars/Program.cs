using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalStore store = new RentalStore("Iasi Rentals", 20);

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            store.AddRental(new Rental(1, customer1, new Car(PriceCode.Regular, "Ford Focus"), 2));
            store.AddRental(new Rental(2, customer3, new Car(PriceCode.Regular, "Renault Clio"), 3));
            store.AddRental(new Rental(3, customer1, new Car(PriceCode.Premium, "BMW 330i"), 1));
            store.AddRental(new Rental(4, customer3, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            store.AddRental(new Rental(5, customer2, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            store.AddRental(new Rental(6, customer1, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            store.AddRental(new Rental(7, customer3, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            store.AddRental(new Rental(8, customer3, new Car(PriceCode.Premium, "Mercedes E320"), 1));
            //store.AddRental(new Rental(9, customer3, new Car(PriceCode.Luxury, "Mercedes Luxury"), 1));


            Console.WriteLine(store.GenerateStatement());
            //Console.WriteLine(store.GenerateStatement());
            //Console.WriteLine(store.GenerateCarCategoryStatement());
            
            
            RentalStore store2 = new RentalStore("Bucuresti Rentals", 30);
            var customer4 = new Customer("Andrei Popescu");
            var customer5 = new Customer("George Nicolae");
            var customer6 = new Customer("Gigel Becali");
            store2.AddRental(new Rental(1, customer4, new Car(PriceCode.Regular, "Ford Focus"), 2));
            store2.AddRental(new Rental(2, customer6, new Car(PriceCode.Regular, "Renault Clio"), 3));
            store2.AddRental(new Rental(3, customer4, new Car(PriceCode.Premium, "BMW 330i"), 1));
            store2.AddRental(new Rental(4, customer6, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            store2.AddRental(new Rental(5, customer5, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            store2.AddRental(new Rental(6, customer4, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            store2.AddRental(new Rental(7, customer6, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            store2.AddRental(new Rental(8, customer6, new Car(PriceCode.Premium, "Mercedes E320"), 1));
            //store2.AddRental(new Rental(9, customer4, new Car(PriceCode.Luxury, "Mercedes Luxury"), 1));

            Console.WriteLine(store2.GenerateStatement());
            Console.WriteLine(store2.GenerateCarCategoryStatement());
            Console.ReadKey();
        }
    }
}
