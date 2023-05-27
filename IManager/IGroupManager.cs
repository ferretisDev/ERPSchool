using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface IGroupManager: IBaseManager<GroupViewModel, Group>
    {
        public List<GroupDetailViewModel> GetAllDetails();
    }
}
