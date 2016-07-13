using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IInboxService
    {
        // Returns email headers in most recent order
        Task<IEnumerable<EmailHeader>> GetEmailHeaders(int userId, int pageSize, int pageCount);

        Task<EmailContent> GetEmailContent(int id);
    }
}
