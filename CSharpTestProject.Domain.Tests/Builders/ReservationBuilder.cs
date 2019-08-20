
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;

namespace CSharpTestProject.Domain.Tests.Builders
{
    public class ReservationBuilder
    {
        private CustomerType _customertype= CustomerType.Regular;
        private int _weekDaysCounter = 3;
        private int _weekendDaysCounter = 0;

        public static ReservationBuilder New()
        {
            return new ReservationBuilder();
        }

        public ReservationBuilder SetCustomerType(CustomerType customerType)
        {
            _customertype = customerType;
            return this;
        }

        public ReservationBuilder SetWeekDaysCounter(int weekDaysCounter)
        {
            _weekDaysCounter = weekDaysCounter;
            return this;
        }

        public ReservationBuilder SetWeekendDaysCounter(int weekendDaysCounter)
        {
            _weekendDaysCounter = weekendDaysCounter;
            return this;
        }

        public Reservation Build()
        {
            Reservation reservation = new Reservation(_customertype, _weekDaysCounter, _weekendDaysCounter);

            return reservation;
        }
    }
}
