using ERPSchool.DetailViewModels;
using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IManager
{
    public interface INeighbourhoodManager : IBaseManager<NeighbourhoodViewModel, Neighbourhood>
    {
        List<NeighbourhoodViewModel> GetByTownId(int townId);

        List<NeighbourhoodDetailViewModel> GetAllDetails();

        NeighbourhoodDetailViewModel GetDetailById(int id);

        List<NeighbourhoodDetailViewModel> GetByFilter(string filter);
    }
}
