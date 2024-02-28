using Entities;
using System.Globalization;
using Services;

namespace AtividadeInterface1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental Data:");
            Console.WriteLine("Car Model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Pickup (dd/MM/yyyy hh:mm):");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);
            
            Console.WriteLine("Return (dd/MM/yyyy hh:mm):");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine());

            CarRental carRental = new CarRental(start,finish,new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("Invoice: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
