using System;
using System.Threading.Tasks;
using Server.Services;

namespace Server.Tests.Mocks
{
    public class MockAccountIdProvider : IAccountIdProvider
    {
        public int CurrentAccountId { get; set; }

        public Task<int> AccountId()
        {
            return Task.FromResult(CurrentAccountId);
        }
    }
}
