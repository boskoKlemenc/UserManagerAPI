using DataAccess.Entities;

namespace UserManagerAPI.Services
{
    public interface IApiClientService
    {
        Task<ApiClient?> GetByApiKeyAsync(string apiKey);
    }
}
