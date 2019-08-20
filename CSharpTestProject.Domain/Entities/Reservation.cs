using CSharpTestProject.Domain.Entities.Enums;

namespace CSharpTestProject.Domain.Entities
{
    public class Reservation
    {
        public CustomerType CustomerType { get; private set; }
        public int DailyOnWeekDaysCounter { get; private set; }
        public int DailyOnWeekendDaysCounter { get; private set; }

        public Reservation(CustomerType customerType, int dailyOnWeekDays, int dailyOnWeekendDays)
        {
            CustomerType = customerType;
            DailyOnWeekDaysCounter = dailyOnWeekDays;
            DailyOnWeekendDaysCounter = dailyOnWeekendDays;
        }
    }
}
