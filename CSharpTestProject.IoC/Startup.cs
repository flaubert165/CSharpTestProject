using CSharpTestProject.Domain.IRepositories;
using CSharpTestProject.Domain.IServices;
using CSharpTestProject.Services.Repositories;
using CSharpTestProject.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpTestProject.IoC
{
    public static class Startup
    {
        public static ServiceProvider ServiceProvider
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                        .AddSingleton<IReservationService, ReservationService>()
                        .AddSingleton<IHotelService, HotelService>()
                        .AddSingleton<IHotelRepository, HotelRepository>()
                        .AddSingleton<IPrintService, PrintService>()
                        .BuildServiceProvider();

                return serviceProvider;
            }
        }
    }
}
