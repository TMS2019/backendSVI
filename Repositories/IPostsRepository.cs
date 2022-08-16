using Infoss.Master.ExchangeRateService.Models;

namespace Infoss.Master.ExchangeRateService.Repositories
{
    public interface IPostsRepository
    {
        public Task<List<MPosts>> Read(int pageNo, int pageSize);
        public Task<MPosts> Read(int id);
        public Task<string> Create(MPosts Mpost);
        public Task<string> Update(MPosts Mpost);
        public Task<string> Delete(int id);

    }
}
