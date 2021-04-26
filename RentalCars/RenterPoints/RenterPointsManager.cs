using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.RenterPoints
{
    public class RenterPointsManager
    {
        private Dictionary<string, Dictionary<int, int>> _customerPoints = new Dictionary<string, Dictionary<int, int>>();
 
        public int GetPointsMax(string customerName)
        {
            int max = 0;

            foreach (KeyValuePair<int, int> pair in _customerPoints[customerName])
            {
                if (pair.Value > max)
                    max = pair.Value;
            }

            return max;
        }

        public void UpdateCustomerRenterPoints(Customer customer)
        {
            customer.FrequentRenterPoints = GetPointsMax(customer.Name);
        }
        
        //Cand este adaugat un rental, se calculeaza punctele pentru acel customer
        //Punctele se tin pentru fiecare rental in parte
        //Pentru un rental facut, se vor aduna punctele obtinute la valoarea calculata la un rental anterior(este mereu valoarea cea mai mare din dictionar)
        public void UpdateRenterPoints(string customerName, int rentalId, PriceCode priceCode, int daysRented)
        {
            if (!_customerPoints.ContainsKey(customerName))
            {
                _customerPoints.Add(customerName, new Dictionary<int, int>(){{ rentalId, 0 }});
            }
            else
            {
                _customerPoints[customerName].Add(rentalId, GetPointsMax(customerName));
            }

            _customerPoints[customerName][rentalId]++;

            if (priceCode == PriceCode.Premium && daysRented > 1)
                _customerPoints[customerName][rentalId]++;
        }

        //Metoda necesara pentru a se putea calcula corect suma ce trebuie platita pentru un rental
        public int CalculateRenterPoints(PriceCode priceCode, int daysRented)
        {
            int frequentRenterPoints = 1;

            if (priceCode == PriceCode.Premium && daysRented > 1)
                frequentRenterPoints++;

            return frequentRenterPoints;
        }
        
        public int GetCustomerRenterPoints(string customerName, int rentalId)
        {
            return _customerPoints[customerName][rentalId];
        }
    }
}

