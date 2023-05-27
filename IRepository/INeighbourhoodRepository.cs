using ERPSchool.Models;

namespace ERPSchool.IRepository
{
    public interface INeighbourhoodRepository: IBaseRepository<Neighbourhood>
    {
        List<Neighbourhood> GetAllDetails();

        Neighbourhood GetDetailById(int id);

        List<Neighbourhood> GetByTownId(int townId);

        List<Neighbourhood> GetByFilter(string filter);
    }
}
