using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Refactoring
{
    class MiniCalculator : RentalSumCalculator
    {
        public override double GetRentalSum(int daysRented, double pricePerDay)
        {
            double rentalSum = 0;

            if (daysRented < 3)
            {
                rentalSum += CalculateRentalSum(pricePerDay, 0.75, daysRented);
            }
            else
            {
                rentalSum += CalculateRentalSum(pricePerDay, 0.75, 3);
                if (daysRented > 3)
                    rentalSum += CalculateRentalSum(pricePerDay, 0.5, daysRented - 3);
            }

            return rentalSum;
        }
    }
}
