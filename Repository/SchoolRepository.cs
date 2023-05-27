using ERPSchool.IRepository;
using ERPSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Repository
{
    public class SchoolRepository : BaseRepository<School>, ISchoolRepository
    {
        public SchoolRepository(AlfredoDbContext context) : base(context) { }

        public List<School> GetAllDetails()
        {
            return _context.Schools
                .Include(p => p.NeighborhoodFkNavigation)
                .OrderByDescending(p => p.Id)
                .ToList();
        }

        public School GetDetailById(int id)
        {
            return _context.Schools
                  .Include(t => t.NeighborhoodFkNavigation.TownFkNavigation)
                  .Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
