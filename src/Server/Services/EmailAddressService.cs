using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Data;
using Server.Models;
using Server.Tools;
using Microsoft.EntityFrameworkCore;

namespace Server.Services
{
    public class EmailAddressService : IEmailAddressService
    {
        private readonly IDbFactory _dbFactory;
        private const int SuggestionRetries = 5;
        public EmailAddressService(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<EmailAddress> CreateAddress(int accountId, string address)
        {
            using (var db = _dbFactory.Create())
            {
                var account = await db.Accounts.SingleAsync(a => a.Id == accountId);

                if (await db.EmailAddresses.AnyAsync(e => e.Address == address))
                {
                    throw new ArgumentException("Address is not unique: " + address);
                }

                var created = db.EmailAddresses.Add(new EmailAddress()
                {
                    Address = address,
                    Account = account
                });

                await db.SaveChangesAsync();

                return created.Entity;
            }
        }


        public Task<IEnumerable<string>> GetAddressRecommendations()
        {
            return GetAddressRecommendations();
        }

        private async Task<IEnumerable<string>> GetAddressRecommendationsInternal(int accumulator = 0)
        {
            // Generate a few random addresses
            var rnd = new Random();
            var suggestions = Enumerable.Range(0, 5)
                .Select(_ => rnd.Next().ToString())
                .ToList();

            using (var db = _dbFactory.Create())
            {
                var existingSuggestions = await db.EmailAddresses
                    .Where(e => suggestions.Contains(e.Address))
                    .Select(e => e.Address)
                    .ToListAsync();

                var okSuggestions = suggestions.Where(s => !existingSuggestions.Contains(s));

                if (!okSuggestions.Any())
                {
                    if (accumulator++ > SuggestionRetries)
                    {
                        // To prevent overflow
                        return Enumerable.Empty<string>();
                    }

                    return await GetAddressRecommendationsInternal(accumulator);
                }

                return okSuggestions;

            }
        }

    }
}
