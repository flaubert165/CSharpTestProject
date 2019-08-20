using System.Collections.Generic;
using System.Linq;
using CSharpTestProject.Domain.Entities;
using CSharpTestProject.Domain.Entities.Enums;
using CSharpTestProject.Domain.IRepositories;
using CSharpTestProject.Domain.IServices;

namespace CSharpTestProject.Services.Services
{
    public class HotelService : IHotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> GetHotels()
        {
            return _hotelRepository.GetHotels();
        }

        public Hotel GetCheapestHotel(Reservation reservation)
        {
            List<Hotel> hotelsList = _hotelRepository.GetHotels()
                                        .OrderBy(h => h.WeekdayRate[CustomerType.Regular])
                                        .ThenBy(h => h.WeekdayRate[CustomerType.Rewards])
                                        .ThenBy(h => h.WeekendRate[CustomerType.Regular])
                                        .ThenBy(h => h.WeekendRate[CustomerType.Rewards]).ToList();

            Hotel cheapestHotel = new Hotel();

            foreach (Hotel currentHotel in hotelsList)
            {
                if (string.IsNullOrEmpty(cheapestHotel.Name))
                {
                    cheapestHotel = currentHotel;
                }
                else
                {
                    var totalCheapest = CalculateTotalRate(cheapestHotel, reservation);

                    var totalCurrent = CalculateTotalRate(currentHotel, reservation);

                    if (totalCheapest > totalCurrent || (totalCheapest == totalCurrent && cheapestHotel.Rating < currentHotel.Rating))
                        cheapestHotel = currentHotel;
                }
            }

            return cheapestHotel;
        }

        private decimal CalculateTotalRate(Hotel hotel, Reservation reservation)
        {
            hotel.WeekdayRate.TryGetValue(reservation.CustomerType, out decimal weekDayRate);
            hotel.WeekendRate.TryGetValue(reservation.CustomerType, out decimal weekendRate);

            return (weekDayRate * reservation.DailyOnWeekDaysCounter) + (weekendRate * reservation.DailyOnWeekendDaysCounter);
        }
    }
}
