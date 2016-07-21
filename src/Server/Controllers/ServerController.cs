using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
{
    public abstract class ServerController : Controller
    {
        private readonly IAccountIdProvider _accountIdProvider;

        protected ServerController(
            IAccountIdProvider accountIdProvider)
        {
            _accountIdProvider = accountIdProvider;
        }

        protected Task<int> AccountId()
        {
            return _accountIdProvider.AccountId();
        }
    }
}
