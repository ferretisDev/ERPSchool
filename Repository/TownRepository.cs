using ERPSchool.IRepository;
using ERPSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Repository
{
    public class TownRepository : BaseRepository<Town>, ITownRepository
    {
        public TownRepository(AlfredoDbContext context) : base(context) { }

        public List<Town> GetAllDetails()
        {
            return _context.Towns
                .Include(t => t.StatesFkNavigation)
                .OrderBy(t => t.StatesFk)
                .ThenBy(t=> t.Name)
                .ToList();
        }

        public List<Town> GetByStateId(int stateId)
        {
            return _context.Towns
                .Where(s => s.StatesFk == stateId)
                .OrderBy(s => s.Name)
                .ToList();
        }

        public Town GetDetailById(int id)
        {
            return _context.Towns
                .Include(t => t.StatesFkNavigation)
                .Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
