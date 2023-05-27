using ERPSchool.Models;

namespace ERPSchool.IRepository
{
    public interface IGroupRepository: IBaseRepository<Group>
    {
        List<Group> GetAllDetails();
    }
}
