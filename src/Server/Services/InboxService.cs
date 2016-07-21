using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data;
using Server.Models;
using Microsoft.EntityFrameworkCore;
using Server.Tools;

namespace Server.Services
{
    public class InboxService : IInboxService
    {
        private readonly IDbFactory _dbFactory;

        public InboxService(
            IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<EmailContent> GetEmailContent(int id)
        {
            using (var db = _dbFactory.Create())
            {
                return await db.EmailContents.SingleOrDefaultAsync(ec => ec.Id == id);
            }
        }

        public async Task<IEnumerable<EmailHeader>> GetEmailHeaders(int accountId, int pageSize, int pageCount)
        {
            using (var db = _dbFactory.Create())
            {
                return await db.EmailHeaders
                    .Query(accountId)
                    .OrderByDescending(eh => eh.Id)
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();
            }
        }
    }
}
