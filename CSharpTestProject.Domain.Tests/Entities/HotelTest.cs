using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using ExpectedObjects;
using Xunit;
using Bogus;

namespace CSharpTestProject.Domain.Tests.Entities
{
    public class HotelTest
    {
        private readonly Hotel _hotel;
        private Faker _fake;

        public HotelTest()
        {
            _fake = new Faker();
            _hotel = new Hotel
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
            );
        }

        [Fact]
        public void CreateNewValidHotel()
        {
            var newHotel = new Hotel(_hotel.Name, _hotel.Rating, _hotel.WeekdayRate, _hotel.WeekendRate);

            _hotel.ToExpectedObject().ShouldEqual(newHotel);
        }

        [Fact]
        public void CreateNewNotValidHotel()
        {
            var newHotel = new Hotel(_fake.Random.Words(), _fake.Random.Int(0, 10), _hotel.WeekdayRate, _hotel.WeekendRate);

            _hotel.ToExpectedObject().ShouldNotEqual(newHotel);
        }
    }
}
