using ERPSchool.Models;
using ERPSchool.ViewModels;

namespace ERPSchool.IRepository
{
    public interface ITownRepository: IBaseRepository<Town>
    {
        List<Town> GetByStateId(int stateId);

        Town GetDetailById(int id);

        List<Town> GetAllDetails();
    }
}
