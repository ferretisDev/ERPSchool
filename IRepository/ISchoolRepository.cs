using ERPSchool.Models;

namespace ERPSchool.IRepository
{
    public interface ISchoolRepository: IBaseRepository<School>
    {
        List<School> GetAllDetails();

        School GetDetailById(int id);
    }
}
