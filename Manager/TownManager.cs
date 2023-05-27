using ERPSchool.DetailViewModels;
using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class TownManager : BaseManager<TownViewModel, Town>, ITownManager
    {
        public readonly ITownRepository _townsRepository;

        public TownManager(ITownRepository repository) : base(repository)
        {
            _townsRepository = repository;
        }

        public List<TownViewModel> GetByStateId(int stateId)
        {
            var entities = _townsRepository.GetByStateId(stateId);

            var towns = entities.Select(p => new TownViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                StatesFk = p.StatesFk
            }).ToList();

            return towns;
        }

        public TownDetailViewModel GetDetailById(int id)
        {
            var entity = _townsRepository.GetDetailById(id);

            var town = new TownDetailViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StatesFk = entity.StatesFk,
                StateName = entity.StatesFkNavigation?.Name
            };

            return town;
        }
        public List<TownDetailViewModel> GetAllDetails()
        {
            var entities = _townsRepository.GetAllDetails();

            return entities.Select(p => new TownDetailViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                StatesFk = p.StatesFk,
                StateName= p.StatesFkNavigation?.Name
            }).ToList();
        }

        public override Town AddConverter(TownViewModel viewModel)
        {
            return new Town()
            {
                Name = viewModel.Name,
                StatesFk = viewModel.StatesFk
            };
        }

        public override Town UpdatedConverter(TownViewModel viewModel, Town entity)
        {
            entity.Name = viewModel.Name;
            entity.StatesFk = viewModel.StatesFk;

            return entity;
        }

        public override TownViewModel SingleConverter(Town entity)
        {
            return new TownViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StatesFk = entity.StatesFk
            };
        }

        public override List<TownViewModel> CollectionConverter(List<Town> entities)
        {
            return entities.Select(p => new TownViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                StatesFk = p.StatesFk,
            }).ToList();
        }

    }
}
