using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    public class InboxController : Controller
    {
        private readonly IInboxService _inboxService;

        public InboxController(
            IInboxService inboxServier)
        {
            _inboxService = inboxServier;
        }
    }
}
