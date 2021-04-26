using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Statement
{
    class CarCategoryStatement
    {
        private StringBuilder _statement;

        public CarCategoryStatement(string rentalOffice)
        {
            _statement = new StringBuilder();
            _statement.Append("Car Category Statement for " + rentalOffice + "\n");
            _statement.Append("Category" + "\t" + "Total Income\n");
            _statement.Append("------------------------------\n");
        }

        public void AddCarCategoryDetails(PriceCode carCategory, double rentalSum)
        {
            _statement.Append(carCategory + "\t\t" + rentalSum + " EUR\n");
        }

        public string GetStatement()
        {
            return _statement.ToString();
        }
    }
}
