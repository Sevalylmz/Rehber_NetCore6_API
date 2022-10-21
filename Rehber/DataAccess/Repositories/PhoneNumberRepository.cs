using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.DataAccess.Repositories
{
    public class PhoneNumberRepository : BaseRepository<PhoneNumber>, IPhoneNumberDAL
    {
        public PhoneNumberRepository(ProjectContext context) : base(context)
        {
        }
    }
}
