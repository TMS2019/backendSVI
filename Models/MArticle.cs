using System.ComponentModel.DataAnnotations.Schema;

namespace Infoss.Master.ExchangeRateService.Models
{

    [Table("master.posts")]
    public class MArticle
    {
        public string RowStatus { get; set; } = string.Empty;
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
        public string context { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;

        public DateTime Created_date { get; set; }
        public DateTime updated_date { get; set; }
        
    }
}
