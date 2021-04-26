using RentalCars.RenterPoints;
using RentalCars.Statement;
using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class RentalStore: RentalSumCalculator
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        private RenterPointsManager renterPointsManager = new RenterPointsManager();

        public RentalStore(string name, double pricePerDay)
        {
            Name = name;
            PricePerDay = pricePerDay;
        }

        public string Name { get; }
        public double PricePerDay { get; }

        public void AddRental(Rental rental)
        {
            if(rental.Car.PriceCode == PriceCode.Luxury && rental.Customer.FrequentRenterPoints < 3)
            {
                Console.WriteLine("This customer needs at least 3 FrequentRenterPoints to rent a Luxury car");
                return;
            }

            _rentals.Add(rental);

            renterPointsManager.UpdateRenterPoints(rental.Customer.Name, rental.Id, rental.Car.PriceCode, rental.DaysRented);
            renterPointsManager.UpdateCustomerRenterPoints(rental.Customer);
        }

        public string GenerateStatement()
        {
            GeneralStatement statementBuilder = new GeneralStatement(Name);

            double totalAmount = 0;
            var factory = new PriceCodeCalculatorFactory();
           
            foreach (var rental in _rentals)
            {
                double rentalSum = 0;
                int daysRented = rental.DaysRented;
                PriceCode priceCode = rental.Car.PriceCode;
                var calculator = factory.GetRentalSumCalculator(priceCode);

                rentalSum = calculator.GetRentalSum(daysRented, PricePerDay);

                int customerRenterPoints = renterPointsManager.GetCustomerRenterPoints(rental.Customer.Name, rental.Id);
                if (customerRenterPoints - renterPointsManager.CalculateRenterPoints(priceCode, daysRented) >= 5 && priceCode != PriceCode.Luxury)
                {
                    rentalSum = calculator.ApplyDiscount(rentalSum);
                }

                statementBuilder.AddRentalDetails(rental.Customer.Name, customerRenterPoints, priceCode, rental.Car.Model, rental.DaysRented, rentalSum);
                totalAmount += rentalSum;
            }
            statementBuilder.AddTotalAmmount(totalAmount);

            return statementBuilder.GetStatement();
        }

        public string GenerateCarCategoryStatement()
        {
            CarCategoryStatement carCategoryStatement = new CarCategoryStatement(Name);

            foreach(PriceCode carCategory in Enum.GetValues(typeof(PriceCode)))
            {
                double rentalSum = 0;
                var factory = new PriceCodeCalculatorFactory();
                var calculator = factory.GetRentalSumCalculator(carCategory);

                foreach (var rental in _rentals)
                {
                    if(carCategory == rental.Car.PriceCode)
                    {
                        double preDisRentalSum = 0;
                        preDisRentalSum += calculator.GetRentalSum(rental.DaysRented, PricePerDay);

                        if ((renterPointsManager.GetCustomerRenterPoints(rental.Customer.Name, rental.Id) - renterPointsManager.CalculateRenterPoints(rental.Car.PriceCode, rental.DaysRented)) >= 5 && rental.Car.PriceCode != PriceCode.Luxury)
                        {
                            preDisRentalSum = calculator.ApplyDiscount(preDisRentalSum);
                        }

                        rentalSum += preDisRentalSum;
                    }
                }
                carCategoryStatement.AddCarCategoryDetails(carCategory, rentalSum);
            }

            return carCategoryStatement.GetStatement();
        }
    }
}