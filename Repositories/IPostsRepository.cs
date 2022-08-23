using Infoss.Master.ExchangeRateService.Models;

namespace Infoss.Master.ExchangeRateService.Repositories
{
    public interface IPostsRepository
    {
<<<<<<< HEAD
        public Task<List<MArticle>> Read(int pageNo, int pageSize);
        public Task<MArticle> Read(int id);
        public Task<string> Create(MArticle Mpost);
        public Task<string> Update(MArticle Mpost);
=======
        public Task<List<MPosts>> Read(int pageNo, int pageSize);
        public Task<MPosts> Read(int id);
        public Task<string> Create(MPosts Mpost);
        public Task<string> Update(MPosts Mpost);
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        public Task<string> Delete(int id);

    }
}
