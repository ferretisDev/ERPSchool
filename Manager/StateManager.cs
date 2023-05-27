using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class StateManager : BaseManager<StateViewModel, State>, IStateManager
    {
        public StateManager(IStateRepository repository) : base(repository) { }

        public override State AddConverter(StateViewModel viewModel)
        {
            return new State()
            {
                Name = viewModel.Name
            };
        }

        public override State UpdatedConverter(StateViewModel viewModel, State entity)
        {
            entity.Name = viewModel.Name;

            return entity;
        }

        public override StateViewModel SingleConverter(State entity)
        {
            return new StateViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public override List<StateViewModel> CollectionConverter(List<State> entities)
        {
            return entities.Select(p => new StateViewModel()
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }
    }
}
