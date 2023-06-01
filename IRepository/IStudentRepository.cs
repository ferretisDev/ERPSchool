using ERPSchool.Models;

namespace ERPSchool.IRepository
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        List<Student> GetAllDetails();
    }
}
