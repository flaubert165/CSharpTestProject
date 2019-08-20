using System.Collections.Generic;
using CSharpTestProject.Domain.Entities.Enums;

namespace CSharpTestProject.Domain.Entities
{
    public class Hotel
    {
        public string Name { get; private set; }
        public int Rating { get; private set; }
        public Dictionary<CustomerType, decimal> WeekdayRate { get; private set; }
        public Dictionary<CustomerType, decimal> WeekendRate { get; private set; }

        public Hotel(string name, int rating, Dictionary<CustomerType, decimal> weekdayRate,
                    Dictionary<CustomerType, decimal> weekendRate)
        {
            Name = name;
            Rating = rating;
            WeekdayRate = weekdayRate;
            WeekendRate = weekendRate;
        }
    }
}
