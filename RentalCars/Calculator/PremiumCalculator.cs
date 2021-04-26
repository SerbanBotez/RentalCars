using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Refactoring
{
    class PremiumCalculator: RentalSumCalculator
    {
        public override double GetRentalSum(int daysRented, double pricePerDay)
        {
            double rentalSum = 0;
            rentalSum += CalculateRentalSum(pricePerDay, 1.5, daysRented);
            return rentalSum;
        }
    }
}
