using RentalCars.Calculator;
using RentalCars.Refactoring;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    class PriceCodeCalculatorFactory
    {
        public RentalSumCalculator GetRentalSumCalculator(PriceCode priceCode)
        {
            switch(priceCode)
            {
                case PriceCode.Regular:
                    return new RegularCalculator();
                case PriceCode.Mini:
                    return new MiniCalculator();
                case PriceCode.Luxury:
                    return new LuxuryCalculator();
                default:
                    return new PremiumCalculator();
            }
        }
    }
}
