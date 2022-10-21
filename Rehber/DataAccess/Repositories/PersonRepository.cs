using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.DataAccess.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonDAL
    {
        public PersonRepository(ProjectContext context) : base(context)
        {
        }
    }
}
