using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrazilTaxService _brazilTaxService = new BrazilTaxService();


        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Start.Subtract(carRental.Finish);

            double BasicPayment = 0;

            if (duration.TotalHours <= 12.0)
            {
                BasicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                BasicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxService.Tax(BasicPayment);

            carRental.Invoice = new Invoice(BasicPayment, tax);
        }
    }
}
