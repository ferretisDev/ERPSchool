using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface ISchoolManager : IBaseManager<SchoolViewModel, School>
    {
        List<SchoolDetailViewModel> GetAllDetails();

        SchoolDetailViewModel GetDetailById(int id);
    }
}
