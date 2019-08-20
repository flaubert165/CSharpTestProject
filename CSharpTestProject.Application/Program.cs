using System;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.IServices;
using CSharpTestProject.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpTestProject.Application
{
    class Program
    {
        public static void Main()
        {
            
            Startup.ServiceProvider.GetService<IPrintService>().PrintInitialMessage();

            var input  = Console.ReadLine();

            Reservation reservation = Startup.ServiceProvider.GetService<IReservationService>()
                                                             .ExtractReservationFromTextInput(input);

            Hotel cheapestHotel = Startup.ServiceProvider.GetService<IHotelService>()
                                                             .GetCheapestHotel(reservation);

            Console.WriteLine(cheapestHotel.Name);
        }
    }
}
