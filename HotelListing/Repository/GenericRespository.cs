using HotelListing.Datas;
using HotelListing.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelListing.Repository
{
    public class GenericRespository<T> : IGenericRespository<T> where T : class
    {
        private readonly DataBaseContext _dataBaseContext;
        private DbSet<T> _db;

        public GenericRespository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _db = _dataBaseContext.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public async Task DeleteByName(string name)
        {
            var entity = await _db.FindAsync(name);
            _db.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> include = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                foreach (var includeValue in include)
                {
                    query = query.Include(includeValue);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, List<string> include = null)
        {

            IQueryable<T> query = _db;

            if(expression != null)
            {
                query = query.Where(expression);
            }
            if (include != null)
            {
                foreach (var includeValue in include)
                {
                    query = query.Include(includeValue);
                }
            }

            if (orderby != null)
            {
                query = orderby(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            _db.AddRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _dataBaseContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
