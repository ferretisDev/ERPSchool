using ERPSchool.IRepository;
using ERPSchool.Models;

namespace ERPSchool.Repository
{
    public class StudentRepository: BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AlfredoDbContext context) : base(context) { }  
    }
}
