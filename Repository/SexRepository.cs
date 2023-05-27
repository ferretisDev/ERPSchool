using ERPSchool.IRepository;
using ERPSchool.Models;

namespace ERPSchool.Repository
{
    public class SexRepository : BaseRepository<Sex>, ISexRepository
    {
        public SexRepository(AlfredoDbContext context) : base(context) { }
    }
}
