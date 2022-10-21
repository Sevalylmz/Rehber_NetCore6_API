using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.DataAccess.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationDAL
    {
        public LocationRepository(ProjectContext context) : base(context)
        {
        }
    }
}
