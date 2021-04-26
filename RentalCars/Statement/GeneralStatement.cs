using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    class GeneralStatement
    {
        private StringBuilder _statement;

        public GeneralStatement(string rentalOffice)
        {
            _statement = new StringBuilder();
            _statement.Append("Rental Record for " + rentalOffice + "\n");
            _statement.Append("------------------------------\n");
        }

        public void AddRentalDetails(string customerName, int customerFrequentRenterPoints, PriceCode priceCode, string carModel, int daysRented, double rentalSum)
        {
            _statement.Append(customerName + "\t" + customerFrequentRenterPoints + "\t" + priceCode + "\t" + carModel + "\t" + daysRented + "d \t" + rentalSum + " EUR\n");
        }

        public void AddTotalAmmount(double totalAmount)
        {
            _statement.Append("------------------------------\n");
            _statement.Append("Total revenue " + totalAmount + " EUR\n");
        }
        public string GetStatement()
        {
            return _statement.ToString();
        }

    }
}
