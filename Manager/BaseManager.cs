using ERPSchool.IManager;
using ERPSchool.IRepository;

namespace ERPSchool.Manager
{
    public class BaseManager<VM, E> : IBaseManager<VM, E> where VM : class where E : class
    {
        public readonly IBaseRepository<E> _repository;

        public BaseManager(IBaseRepository<E> repository)
        {
            _repository = repository;
        }

        public VM Add(VM viewModel)
        {
            E entity = this.AddConverter(viewModel);

            _repository.Add(entity);

            return viewModel;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<VM> GetAll()
        {
            List<E> entities = _repository.GetAll();

            List<VM> viewModel = this.CollectionConverter(entities);

            return viewModel;
        }

        public virtual VM GetById(int id)
        {
            E entity = _repository.GetById(id);

            return this.SingleConverter(entity);
        }

        public void Update(int id, VM viewModel)
        {
            E entity = _repository.GetById(id);

            entity = this.UpdatedConverter(viewModel, entity);

            _repository.Update(entity);
        }

        #region Converter
        public virtual E AddConverter(VM viewModel)
        {
            throw new NotImplementedException();
        }

        public virtual E UpdatedConverter(VM viewModel, E entity)
        {
            throw new NotImplementedException();
        }

        public virtual VM SingleConverter(E entity)
        {
            throw new NotImplementedException();
        }

        public virtual List<VM> CollectionConverter(List<E> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
