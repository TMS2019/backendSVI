using Infoss.Master.ExchangeRateService.Models;

namespace Infoss.Master.ExchangeRateService.Repositories
{
    public interface IPostsRepository
    {
 
        public Task<List<MArticle>> Read(int pageNo, int pageSize);
        public Task<MArticle> Read(int id);
        public Task<string> Create(MArticle Mpost);
        public Task<string> Update(MArticle Mpost);
 
 
 
 
        public Task<string> Delete(int id);

    }
}
