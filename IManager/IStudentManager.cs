using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface IStudentManager: IBaseManager<StudentViewModel, Student>
    {
        List<StudentDetailViewModel> GetAllDetails();
    }
}
