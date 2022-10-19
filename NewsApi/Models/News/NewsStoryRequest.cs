using System.ComponentModel.DataAnnotations;

namespace NewsApi.Models.News
{
    public class NewsStoryRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
