using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface IGroupManager: IBaseManager<GroupViewModel, Group>
    {
        List<GroupDetailViewModel> GetAllDetails();

        GroupDetailViewModel GetDetailById(int id);
    }
}
