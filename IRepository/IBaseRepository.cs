namespace ERPSchool.IRepository
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
