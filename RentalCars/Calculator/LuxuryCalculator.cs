using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Calculator
{
    class LuxuryCalculator: RentalSumCalculator
    {
        public override double GetRentalSum(int daysRented, double PricePerDay)
        {
            double rentalSum = 0;
            //rentalSum += CalculateRentalSum(PricePerDay, 2.5, daysRented);
            rentalSum += 70;

            return rentalSum;
        }
    }
}
