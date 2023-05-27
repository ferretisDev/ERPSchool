namespace ERPSchool.IManager
{
    public interface IBaseManager<VM, E> where VM : class where E : class
    {
        List<VM> GetAll();

        VM GetById(int id);

        VM Add(VM entity);

        void Update(int id, VM entity);

        void Delete(int id);
    }
}
