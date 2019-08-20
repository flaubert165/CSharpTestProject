using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;

namespace CSharpTestProject.Domain.IServices
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();
        Hotel GetCheapestHotel(Reservation reservation);
    }
}
