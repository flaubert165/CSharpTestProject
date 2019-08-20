using System.Collections.Generic;
using CSharpTestProject.Domain.Entities;

namespace CSharpTestProject.Domain.IRepositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();
    }
}
