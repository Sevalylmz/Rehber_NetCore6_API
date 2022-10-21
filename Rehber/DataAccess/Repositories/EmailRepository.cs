using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.Models;

namespace Rehber.DataAccess.Repositories
{
    public class EmailRepository : BaseRepository<Email>, IEmailDAL
    {
        public EmailRepository(ProjectContext context) : base(context)
        {
        }
    }
}
