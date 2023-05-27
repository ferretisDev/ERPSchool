using ERPSchool.DetailViewModels;
using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class NeighbourhoodManager : BaseManager<NeighbourhoodViewModel, Neighbourhood>, INeighbourhoodManager
    {
        public readonly INeighbourhoodRepository _neighbourhoodRepository;

        public NeighbourhoodManager(INeighbourhoodRepository repository) : base(repository)
        {
            _neighbourhoodRepository = repository;
        }

        public override Neighbourhood AddConverter(NeighbourhoodViewModel viewModel)
        {
            return new Neighbourhood()
            {
                Name = viewModel.Name,
                TownFk = viewModel.TownFk
            };
        }

        public override Neighbourhood UpdatedConverter(NeighbourhoodViewModel viewModel, Neighbourhood entity)
        {
            entity.Name = viewModel.Name;
            entity.TownFk = viewModel.TownFk;

            return entity;
        }

        public override NeighbourhoodViewModel SingleConverter(Neighbourhood entity)
        {
            return new NeighbourhoodViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                TownFk = entity.TownFk
            };
        }

        public override List<NeighbourhoodViewModel> CollectionConverter(List<Neighbourhood> entities)
        {
            return entities.Select(p => new NeighbourhoodViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                TownFk = p.TownFk
            }).ToList();
        }

        public List<NeighbourhoodViewModel> GetByTownId(int townId)
        {
            var entities = _neighbourhoodRepository.GetByTownId(townId);

            return entities.Select(p => new NeighbourhoodViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                TownFk = p.TownFk
            }).ToList();
        }

        public List<NeighbourhoodDetailViewModel> GetAllDetails()
        {
            var entities = _neighbourhoodRepository.GetAllDetails();

            return entities.Select(p => new NeighbourhoodDetailViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                TownFk = p.TownFk,
                TownName = p.TownFkNavigation?.Name,
                StateFk = p.TownFkNavigation?.StatesFk
            }).ToList();
        }

        public List<NeighbourhoodDetailViewModel> GetByFilter(string filter)
        {
            var entity = _neighbourhoodRepository.GetByFilter(filter);

            var neighborhoods = entity.Select(p => new NeighbourhoodDetailViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                TownFk = p.TownFk,
                TownName = p.TownFkNavigation?.Name
            }).ToList();

            return neighborhoods;
        }

        public NeighbourhoodDetailViewModel GetDetailById(int id)
        {
            var entity = _neighbourhoodRepository.GetDetailById(id);

            var neighborhoods = new NeighbourhoodDetailViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                TownFk = entity.TownFk,
                StateFk = entity.TownFkNavigation?.StatesFk,
                TownName = entity.TownFkNavigation?.Name
            };
            return neighborhoods;
        }
    }
}
