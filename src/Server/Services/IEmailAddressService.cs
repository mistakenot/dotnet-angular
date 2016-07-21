using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IEmailAddressService
    {
        Task<EmailAddress> CreateAddress(int accountId, string address);

        Task<IEnumerable<string>> GetAddressRecommendations();
    }
}
