using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infoss.Master.ExchangeRateService.Repositories;
using Infoss.Master.ExchangeRateService.Models;


namespace Infoss.Master.ExchangeRateService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IPostsRepository iPostsRepository;
        public IConfigurationRoot Configuration { get; }

        public ArticleController()
        {
            IConfiguration Configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").
                Build();

            iPostsRepository = new PostsRepository(Configuration);
        }

        // GET <ExchangeRateController>/5
        [HttpGet("{id}")]
        public async Task<MArticle> Get(int id)
        {
            return await iPostsRepository.Read(id);
        }

        // GET <ExchangeRateController>/1/20
        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IEnumerable<MArticle>> Get(int pageNo, int pageSize)
        {
            return await iPostsRepository.Read(pageNo, pageSize);
        }

       
        [HttpPost]
        public async Task<string> Post(MArticle mposts)
        {
            
            return await iPostsRepository.Create(mposts);
        }

        // PUT <ExchangeRateController>
        [HttpPut]
        public async Task<string> Put(MArticle mposts)
        {
            return await iPostsRepository.Update(mposts);
        }

        // DELETE <ExchangeRateController>/5/Admin
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await iPostsRepository.Delete(id);
        }

    }
}
