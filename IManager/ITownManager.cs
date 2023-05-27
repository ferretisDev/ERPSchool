using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface ITownManager: IBaseManager<TownViewModel, Town>
    {
        List<TownViewModel> GetByStateId(int stateId);

        TownDetailViewModel GetDetailById(int id);

        List<TownDetailViewModel> GetAllDetails();
    }
}
