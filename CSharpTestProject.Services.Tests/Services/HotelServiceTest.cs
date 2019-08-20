using System.Collections;
using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.IRepositories;
using CSharpTestProject.Domain.IServices;
using CSharpTestProject.Services.Services;
using Moq;
using Xunit;

namespace CSharpTestProject.Services.Tests.Services
{
    public class HotelDataGenerator : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> GetHotelsFromDataGenerator()
        {
            yield return new object[]
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
                    Rating = 3,
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

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }

    public class HotelServiceTest
    {
        private Hotel _expected;
        private HotelService _hotelService;
        private readonly Mock<IHotelRepository> _hotelRepositoryMock;

        public HotelServiceTest()
        {
            _hotelRepositoryMock = new Mock<IHotelRepository>();
            _hotelService = new HotelService(_hotelRepositoryMock.Object);
            _expected = new Hotel
            {
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
            };
        }

        [Theory]
        [MemberData(nameof(HotelDataGenerator.GetHotelsFromDataGenerator), MemberType = typeof(HotelDataGenerator))]
        public void GetHotels(Hotel a, Hotel b, Hotel c)
        {
            List<Hotel> hotelsList = new List<Hotel>();
            hotelsList.Add(a);
            hotelsList.Add(b);
            hotelsList.Add(c);

            _hotelRepositoryMock.Setup(h => h.GetHotels()).Returns(hotelsList);

            Assert.True(hotelsList[0] == a);
            Assert.True(hotelsList[1] == b);
            Assert.True(hotelsList[2] == c);
        }

        [Fact]
        public void GetCheapestHotel()
        {
            var hotelService = new Mock<IHotelService>();

            Reservation reservation = new Reservation(CustomerType.Regular, 1, 2);

            hotelService.Setup(s => s.GetCheapestHotel(reservation)).Returns(_expected);

            Assert.True(_expected.Name.Equals("Bridgewood"));
        }
    }
}
