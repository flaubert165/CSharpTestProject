using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.IRepositories;

namespace CSharpTestProject.Services.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        public List<Hotel> GetHotels()
        {
            return new List<Hotel>
            {
                new Hotel {
                    Name = "Lakewood",
                    Rating = 3,
                    WeekdayRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 110.0m},
                        { CustomerType.Rewards, 80.0m}
                    },
                    WeekendRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 90.0m},
                        { CustomerType.Rewards, 80.0m}
                    }
                },
                new Hotel {
                    Name = "Bridgewood",
                    Rating = 4,
                    WeekdayRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 160.0m},
                        { CustomerType.Rewards, 110.0m}
                    },
                    WeekendRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 60.0m},
                        { CustomerType.Rewards, 50.0m}
                    }
                },
                new Hotel {
                    Name = "Ridgewood",
                    Rating = 5,
                    WeekdayRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 220.0m},
                        { CustomerType.Rewards, 100.0m}
                    },
                    WeekendRate = new Dictionary<CustomerType, decimal> {
                        { CustomerType.Regular, 150.0m},
                        { CustomerType.Rewards, 40.0m}
                    }
                }
            };
        }
    }
}
