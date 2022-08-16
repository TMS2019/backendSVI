using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infoss.Master.ExchangeRateService.Repositories;
using Infoss.Master.ExchangeRateService.Models;
using static Infoss.Master.ExchangeRateService.Models.Mposts;

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
        public async Task<Mposts> Get(int id)
        {
            return await iPostsRepository.Read(id);
        }

        // GET <ExchangeRateController>/1/20
        [HttpGet("{pageNo}/{pageSize}")]
        public async Task<IEnumerable<Mposts>> Get(int pageNo, int pageSize)
        {
            return await iPostsRepository.Read(pageNo, pageSize);
        }

        // POST <ExchangeRateController>
      
        //private List<Item> ArticleList()
        //{
        //    return new List<Item>()
        //    {
        //        new Item()
        //        {
        //            Id=1,Name="publish"
        //        },
        //         new Item()
        //        {
        //            Id=2,Name="draft"
        //        },
        //          new Item()
        //        {
        //            Id=3,Name="thrash"
        //        },

        //    };
        //}
        [HttpPost]
        public async Task<string> Post(Mposts mposts)
        {
            
            return await iPostsRepository.Create(mposts);
        }

        // PUT <ExchangeRateController>
        [HttpPut]
        public async Task<string> Put(Mposts mposts)
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
