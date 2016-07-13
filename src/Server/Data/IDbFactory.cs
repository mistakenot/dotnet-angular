
namespace Server.Data
{
    public interface IDbFactory
    {
        ApplicationDbContext Create();
    }
}
