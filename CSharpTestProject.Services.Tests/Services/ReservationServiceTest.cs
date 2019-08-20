using System;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Services.Services;
using ExpectedObjects;
using Xunit;

namespace CSharpTestProject.Services.Tests.Services
{
    public class ReservationServiceTest
    {
        public readonly Reservation _reservation;
        public readonly ReservationService _reservationService;

        public ReservationServiceTest()
        {
            _reservation = new Reservation(CustomerType.Regular, 3, 0);

            _reservationService = new ReservationService();
        }

        [Theory]
        [InlineData("Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)")]
        public void ExtractReservationFromTextInput(string input)
        {
            Reservation newReservation = _reservationService.ExtractReservationFromTextInput(input);

            _reservation.ToExpectedObject().ShouldEqual(newReservation);
        }

        [Theory]
        [InlineData("")]
        public void ExtractReservationFromNullOrEmptyTextInput(string input)
        {
            Assert.Throws<ArgumentException>(() => _reservationService.ExtractReservationFromTextInput(input));
        }
    }
}
