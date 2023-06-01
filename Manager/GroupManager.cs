using ERPSchool.DetailViewModels;
using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class GroupManager : BaseManager<GroupViewModel, Group>, IGroupManager
    {
        public readonly IGroupRepository _groupRepository;

        public GroupManager(IGroupRepository repository) : base(repository)
        {
            _groupRepository = repository;
        }

        public override Group AddConverter(GroupViewModel viewModel)
        {
            return new Group()
            {
                Name = viewModel.Name,
                MaxStudents = viewModel.MaxStudents,
                SchoolFk = viewModel.SchoolFk
            };
        }

        public override Group UpdatedConverter(GroupViewModel viewModel, Group entity)
        {
            entity.Name = viewModel.Name;
            entity.MaxStudents = viewModel.MaxStudents;
            entity.SchoolFk = viewModel.SchoolFk;

            return entity;
        }

        public override GroupViewModel SingleConverter(Group entity)
        {
            return new GroupViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                MaxStudents = entity.MaxStudents,
                SchoolFk = entity.SchoolFk
            };
        }

        public override List<GroupViewModel> CollectionConverter(List<Group> entities)
        {
            return entities.Select(p => new GroupViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                MaxStudents = p.MaxStudents,
                SchoolFk = p.SchoolFk
            }).ToList();
        }

        public List<GroupDetailViewModel> GetAllDetails()
        {
            var entities = _groupRepository.GetAllDetails();

            return entities.Select(p => new GroupDetailViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                MaxStudents = p.MaxStudents,
                SchoolFk = p.SchoolFk,
                SchoolName = p.SchoolFkNavigation?.Name
            }).ToList();
        }

        public GroupDetailViewModel GetDetailById(int id)
        {
            var entity = _groupRepository.GetDetailById(id);

            return new GroupDetailViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                MaxStudents = entity.MaxStudents,
                SchoolFk = entity.SchoolFk,
                SchoolName = entity.SchoolFkNavigation?.Name,
            };
        }
    }
}
