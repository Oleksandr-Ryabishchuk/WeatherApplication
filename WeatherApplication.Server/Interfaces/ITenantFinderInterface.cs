using WeatherApplication.Server.Data;

namespace WeatherApplication.Server.Interfaces
{
    public interface ITenantFinderInterface
    {
        Task<Guid> GetTenantId(string userEmail, ApplicationDbContext dbContext);
    }
}
