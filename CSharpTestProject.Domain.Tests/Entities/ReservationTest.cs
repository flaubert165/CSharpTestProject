using System;
using Bogus;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.Tests.Builders;
using ExpectedObjects;
using Xunit;

namespace CSharpTestProject.Domain.Tests.Entities
{
    public class ReservationTest
    {
        public readonly Reservation _reservation;
        public Faker _faker;

        public ReservationTest()
        {
            _faker = new Faker();
            _reservation = new Reservation(CustomerType.Regular, 3, 2);
        }

        [Fact]
        public void CreateNewValidReservation()
        {
            var newReservation = new Reservation(_reservation.CustomerType, _reservation.DailyOnWeekDaysCounter, _reservation.DailyOnWeekendDaysCounter);

            _reservation.ToExpectedObject().ShouldEqual(newReservation);
        }

        [Theory]
        [InlineData(CustomerType.Rewards)]
        [InlineData(CustomerType.Regular)]
        public void ReservationValidCustomerType(CustomerType customerType)
        {
            var reservation = ReservationBuilder.New().SetCustomerType(customerType).Build();

            Assert.True(reservation.CustomerType == customerType);
            //Assert.Throws<ArgumentException>(() => ReservationBuilder.New().SetCustomerType(customerType).Build());
        }
    }
}