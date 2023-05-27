using ERPSchool.IRepository;
using ERPSchool.Models;

namespace ERPSchool.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly AlfredoDbContext _context;

        public BaseRepository(AlfredoDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            _context.Set<T>().Remove(entity);
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>()
                .ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

