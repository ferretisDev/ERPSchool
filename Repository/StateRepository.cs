using ERPSchool.IRepository;
using ERPSchool.Models;

namespace ERPSchool.Repository
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(AlfredoDbContext context) : base(context) { }  
    }
}
