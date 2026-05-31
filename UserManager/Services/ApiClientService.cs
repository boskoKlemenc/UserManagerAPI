using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserManagerAPI.Services
{
    public class ApiClientService : IApiClientService
    {
        private readonly MainDbContext _dbContext;

        public ApiClientService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiClient?> GetByApiKeyAsync(string apiKey)
        {
            return await _dbContext.ApiClients.FirstOrDefaultAsync(x => x.ApiKey == apiKey);
        }
    }
}
