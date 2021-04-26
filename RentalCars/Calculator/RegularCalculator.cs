using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Refactoring
{
    class RegularCalculator : RentalSumCalculator
    {
        public override double GetRentalSum(int daysRented, double pricePerDay)
        {
            double rentalSum = 0;

            rentalSum += CalculateRentalSum(pricePerDay, 1, 2);
            if (daysRented > 2)
            {
                rentalSum += CalculateRentalSum(pricePerDay, 0.75, daysRented - 2);
            }

            return rentalSum;
        }
    }
}
