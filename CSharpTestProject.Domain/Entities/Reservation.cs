using CSharpTestProject.Domain.Entities.Enums;

namespace CSharpTestProject.Domain.Entities
{
    public class Reservation
    {
        public CustomerType CustomerType { get; set; }
        public int DailyOnWeekDaysCounter { get; set; }
        public int DailyOnWeekendDaysCounter { get; set; }

        public Reservation(CustomerType customerType, int dailyOnWeekDays, int dailyOnWeekendDays)
        {
            CustomerType = customerType;
            DailyOnWeekDaysCounter = dailyOnWeekDays;
            DailyOnWeekendDaysCounter = dailyOnWeekendDays;
        }
    }
}
