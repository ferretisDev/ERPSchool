using ERPSchool.IRepository;
using ERPSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Repository
{
    public class StudentRepository: BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AlfredoDbContext context) : base(context) { }

        public List<Student> GetAllDetails()
        {
            return _context.Students
                .Include(s=> s.SexFkNavigation)
                .Include(g=> g.GroupFkNavigation)
                .OrderBy(s=> s.Name)
                .ToList();
        }
    }
}
