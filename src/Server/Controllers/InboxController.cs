using Server.Models;
using Server.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("/Inbox")]
    public class InboxController : ServerController
    {
        private const int DEFAULT_PAGE_SIZE = 10;

        private readonly IInboxService _inboxService;

        public InboxController(
            IAccountIdProvider accountIdProvider,
            IInboxService inboxService)
            : base(accountIdProvider)
        {
            _inboxService = inboxService;
        }

        [HttpGet]
        [Route("Headers")]
        public async Task<IEnumerable<EmailHeader>> GetEmailHeaders(int pageCount, int pageSize = DEFAULT_PAGE_SIZE)
        {
            pageSize = Math.Min(pageSize, DEFAULT_PAGE_SIZE);
            var accountId = await AccountId();
            return await _inboxService.GetEmailHeaders(accountId, pageSize, pageCount);
        }

        [HttpGet]
        [Route("Content/{id:int}")]
        public async Task<EmailContent> GetEmailContents(int id)
        {
            return await _inboxService.GetEmailContent(id);
        }

    }
}
