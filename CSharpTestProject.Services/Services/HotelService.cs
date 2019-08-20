using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;
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
            Hotel cheapestHotel = null;

            List<Hotel> hotelsList = _hotelRepository.GetHotels();

            foreach (Hotel currentHotel in hotelsList)
            {
                if (cheapestHotel == null)
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
