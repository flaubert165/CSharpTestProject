using System.Collections.Generic;
using System.Linq;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.IRepositories;

namespace CSharpTestProject.Services.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = new List<Hotel>
            {
                new Hotel
                (
                    "Lakewood",
                    3,
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 110.0m},
                        { CustomerType.Rewards, 80.0m}
                    },
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 90.0m},
                        { CustomerType.Rewards, 80.0m}
                    }
                ),
                new Hotel
                (
                    "Bridgewood",
                    4,
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 160.0m},
                        { CustomerType.Rewards, 110.0m}
                    },
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 60.0m},
                        { CustomerType.Rewards, 50.0m}
                    }
                ),
                new Hotel
                (
                    "Ridgewood",
                    5,
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 220.0m},
                        { CustomerType.Rewards, 100.0m}
                    },
                    new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 150.0m},
                        { CustomerType.Rewards, 40.0m}
                    }
                )
            };

            return hotels.OrderBy(h => h.WeekdayRate[CustomerType.Regular])
                                        .ThenBy(h => h.WeekdayRate[CustomerType.Rewards])
                                        .ThenBy(h => h.WeekendRate[CustomerType.Regular])
                                        .ThenBy(h => h.WeekendRate[CustomerType.Rewards]).ToList();
        }
    }
}
