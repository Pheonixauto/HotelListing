using HotelListing.Datas;
using HotelListing.IRepository;
using HotelListing.Models;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dataBaseContext ;

        private IGenericRespository<Country> _countries;
        private IGenericRespository<Hotel> _hotels;

        public UnitOfWork(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public IGenericRespository<Country> Countries => _countries ??= new GenericRespository<Country>(_dataBaseContext);

        public IGenericRespository<Hotel> Hotels => _hotels ??= new GenericRespository<Hotel>(_dataBaseContext);

        public void Dispose()
        {
            _dataBaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

      
        public async Task Save()
        {
           await _dataBaseContext.SaveChangesAsync();
        }
    }
}
