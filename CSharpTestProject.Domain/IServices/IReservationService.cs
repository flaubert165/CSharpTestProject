using CSharpTestProject.Domain.Entities;

namespace CSharpTestProject.Domain.IServices
{
    public interface IReservationService
    {
        Reservation ExtractReservationFromTextInput(string input);
    }
}
