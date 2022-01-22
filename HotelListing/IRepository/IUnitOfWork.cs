using HotelListing.Models;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespository<Country> Countries { get; }
        IGenericRespository<Hotel> Hotels { get; }
        Task Save();

    }
}
