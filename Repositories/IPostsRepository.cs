using Infoss.Master.ExchangeRateService.Models;

namespace Infoss.Master.ExchangeRateService.Repositories
{
    public interface IPostsRepository
    {
        public Task<List<Mposts>> Read(int pageNo, int pageSize);
        public Task<Mposts> Read(int id);
        public Task<string> Create(Mposts Mpost);
        public Task<string> Update(Mposts Mpost);
        public Task<string> Delete(int id);

    }
}
