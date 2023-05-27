using ERPSchool.IManager;
using ERPSchool.IRepository;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.Manager
{
    public class StudentManager : BaseManager<StudentViewModel, Student>, IStudentManager
    {
        public readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository repository) : base(repository)
        {
            _studentRepository = repository;
        }

        public override Student AddConverter(StudentViewModel viewModel)
        {
            return new Student()
            {
                Name = viewModel.Name,
                BirthDate = viewModel.BirthDate,
                SexFk = viewModel.SexFk,
                GroupFk = viewModel.GroupFk
            };
        }

        public override Student UpdatedConverter(StudentViewModel viewModel, Student entity)
        {
            entity.Name = viewModel.Name;
            entity.BirthDate = viewModel.BirthDate;
            entity.SexFk = viewModel.SexFk;
            entity.GroupFk = viewModel.GroupFk;
            return entity;
        }

        public override StudentViewModel SingleConverter(Student entity)
        {
            return new StudentViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                BirthDate = entity.BirthDate,
                SexFk = entity.SexFk,
                GroupFk = entity.GroupFk
            };
        }

        public override List<StudentViewModel> CollectionConverter(List<Student> entities)
        {
            return entities.Select(p => new StudentViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate,
                SexFk = p.SexFk,
                GroupFk= p.GroupFk
            }).ToList();
        }
    }
}
