using System.Threading.Tasks;

namespace Server.Services
{
    public interface IAccountIdProvider
    {
        Task<int> AccountId();
    }
}
