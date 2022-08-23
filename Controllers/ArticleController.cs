using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infoss.Master.ExchangeRateService.Repositories;
using Infoss.Master.ExchangeRateService.Models;
<<<<<<< HEAD

=======
 
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8

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
<<<<<<< HEAD
        public async Task<MArticle> Get(int id)
=======
        public async Task<MPosts> Get(int id)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            return await iPostsRepository.Read(id);
        }

        // GET <ExchangeRateController>/1/20
        [HttpGet("{pageNo}/{pageSize}")]
<<<<<<< HEAD
        public async Task<IEnumerable<MArticle>> Get(int pageNo, int pageSize)
=======
        public async Task<IEnumerable<MPosts>> Get(int pageNo, int pageSize)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            return await iPostsRepository.Read(pageNo, pageSize);
        }

       
        [HttpPost]
<<<<<<< HEAD
        public async Task<string> Post(MArticle mposts)
=======
        public async Task<string> Post(MPosts mposts)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
        {
            
            return await iPostsRepository.Create(mposts);
        }

        // PUT <ExchangeRateController>
        [HttpPut]
<<<<<<< HEAD
        public async Task<string> Put(MArticle mposts)
=======
        public async Task<string> Put(MPosts mposts)
>>>>>>> 839a904f3d8485ea1399bcdb298c0bab7c708da8
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
