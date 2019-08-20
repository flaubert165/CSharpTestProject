using System;
using System.Collections.Generic;
using System.Linq;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.IServices;

namespace CSharpTestProject.Services.Services
{
    public class ReservationService : IReservationService
    {
        public Reservation ExtractReservationFromTextInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("The input is null or invalid!");

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '(', ')' };

            List<string> words = new List<string>(input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries));

            Enum.TryParse(words[0], out CustomerType customerType);
            int weekDaysCounter = 0;
            int weekEndcounter = 0;

            foreach (string item in words.Skip(2))
            {
                if (item.StartsWith("sat", StringComparison.Ordinal) || item.StartsWith("sun", StringComparison.Ordinal))
                {
                    weekEndcounter++;
                }
                else if (item.StartsWith("mon", StringComparison.Ordinal) ||
                         item.StartsWith("tue", StringComparison.Ordinal) ||
                         item.StartsWith("wed", StringComparison.Ordinal) ||
                         item.StartsWith("thu", StringComparison.Ordinal) ||
                         item.StartsWith("fri", StringComparison.Ordinal))
                {
                    weekDaysCounter++;
                }
            }

            return new Reservation(customerType, weekDaysCounter, weekEndcounter);
        }
    }
}
