using NewsApi.Entities;
using NewsApi.Models.System;

namespace NewsApi.Models.News
{
    public class NewsStoryResponse : BaseApiResponse
    {
        public NewsStory NewsStory { get; set; }        
    }
}
