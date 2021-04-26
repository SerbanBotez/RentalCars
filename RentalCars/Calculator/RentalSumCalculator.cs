using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    public class RentalSumCalculator
    {
        public double ApplyDiscount(double rentalSum)
        {
            return rentalSum * 0.95;
        }

        public double CalculateRentalSum(double PricePerDay, double pricePercentage, int daysRented)
        {
            double rentalSum = PricePerDay * pricePercentage * daysRented;
            return rentalSum;
        }

        public virtual double GetRentalSum(int daysRented, double PricePerDay)
        {
            return 0;
        }
    }
}
