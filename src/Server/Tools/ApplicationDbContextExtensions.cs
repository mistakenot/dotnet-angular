using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Tools
{
    public static class ApplicationDbContextExtensions
    {
        public static IQueryable<T> Query<T>(this IQueryable<T> collection, int accountId)
            where T : IOwnedEntity
        {
            return collection.Where(entity =>
                entity.AccountId == accountId &&
                entity.DeletedAt == null);
        }
    }
}
