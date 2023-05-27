using ERPSchool.DetailViewModels;
using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.Repository;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class SchoolManager : BaseManager<SchoolViewModel, School>, ISchoolManager
    {
        public readonly ISchoolRepository _schoolRepository;

        public SchoolManager(ISchoolRepository repository): base(repository)
        {
            _schoolRepository = repository;
        }

        public override School AddConverter(SchoolViewModel viewModel)
        {
            return new School()
            {
                Name = viewModel.Name,
                StreetName = viewModel.StreetName,
                Number = viewModel.Number,
                NeighborhoodFk = viewModel.NeighborhoodFk
            };
        }

        public override School UpdatedConverter(SchoolViewModel viewModel, School entity)
        {
            entity.Name = viewModel.Name;
            entity.StreetName = viewModel.StreetName;
            entity.Number = viewModel.Number;
            entity.NeighborhoodFk = viewModel.NeighborhoodFk;

            return entity;
        }

        public override SchoolViewModel SingleConverter(School entity)
        {
            return new SchoolViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StreetName = entity.StreetName,
                Number = entity.Number,
                NeighborhoodFk= entity.NeighborhoodFk,
            };
        }

        public override List<SchoolViewModel> CollectionConverter(List<School> entities)
        {
            return entities.Select(p => new SchoolViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                StreetName = p.StreetName,
                Number = p.Number,
                NeighborhoodFk= p.NeighborhoodFk
            }).ToList();
        }

        public List<SchoolDetailViewModel> GetAllDetails()
        {
            var entities = _schoolRepository.GetAllDetails();

            return entities.Select(s => new SchoolDetailViewModel()
            {
                Id=s.Id,
                Name=s.Name,
                StreetName=s.StreetName,
                Number = s.Number,
                NeighborhoodFk= s.NeighborhoodFk,
                NeighborhoodName = s.NeighborhoodFkNavigation?.Name
            }).ToList();
        }

        public SchoolDetailViewModel GetDetailById(int id)
        {
            var entity = _schoolRepository.GetDetailById(id);

            return new SchoolDetailViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StreetName = entity.StreetName,
                Number = entity.Number,
                NeighborhoodFk = entity.NeighborhoodFk,
                NeighborhoodName = entity.NeighborhoodFkNavigation?.Name,
                StatesFk = entity.NeighborhoodFkNavigation?.TownFkNavigation?.StatesFk,
                TownFk = entity.NeighborhoodFkNavigation?.TownFk
            };
        }
    }
}
