using ERPSchool.IRepository;
using ERPSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSchool.Repository
{
    public class NeighbourhoodRepository : BaseRepository<Neighbourhood>, INeighbourhoodRepository
    {
        public NeighbourhoodRepository(AlfredoDbContext context) : base(context) { }

        public List<Neighbourhood> GetAllDetails()
        {
            return _context.Neighbourhoods
                .Include(t => t.TownFkNavigation)
                .OrderBy(t => t.Name)
                .ToList();
        }

        public List<Neighbourhood> GetByFilter(string filter)
        {
            object result;

            if (filter != null)
            {
                result = _context.Neighbourhoods
                    .Include(t => t.TownFkNavigation)
                    .Where(n => n.Name.StartsWith(filter))
                    .OrderBy(t => t.Name)
                    .ToList();
            }
            else
            {
                result = _context.Neighbourhoods
                    .Include(t => t.TownFkNavigation)
                    .OrderBy(t => t.Name)
                    .ToList();
            }

            return (List<Neighbourhood>)result;
        }

        public List<Neighbourhood> GetByTownId(int townId)
        {
            return _context.Neighbourhoods
                .Where(n => n.TownFk == townId)
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Neighbourhood GetDetailById(int id)
        {
            return _context.Neighbourhoods
                .Include(t => t.TownFkNavigation)
                .Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
