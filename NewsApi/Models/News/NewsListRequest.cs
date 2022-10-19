using System.ComponentModel.DataAnnotations;

namespace NewsApi.Models.News
{
    public class NewsListRequest
    {
        public int? Page { get; set; }

        [Required]
        public int? PageSize { get; set; }
    }
}
