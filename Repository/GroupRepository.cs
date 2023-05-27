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
    }
}
