using ERPSchool.IRepository;
using ERPSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Repository
{
    public class GroupRepository: BaseRepository<Group>, IGroupRepository
    {
      public  GroupRepository(AlfredoDbContext context): base(context) { }

        public List<Group> GetAllDetails()
        {
            return _context.Groups
                .Include(g => g.SchoolFkNavigation)
                .ToList();
        }

        public List<Group> GetBySchoolId(int schoolId)
        {
            return _context.Groups
                .Where(s=> s.SchoolFk ==  schoolId)
                .OrderBy(s=> s.Name)
                .ToList();
        }

        public Group GetDetailById(int id)
        {
            return _context.Groups
                .Include(s => s.SchoolFkNavigation)
                .Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
