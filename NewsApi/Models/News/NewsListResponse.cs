using NewsApi.Entities;
using NewsApi.Models.System;
using System.Collections.Generic;

namespace NewsApi.Models.News
{
    public class NewsListResponse : BaseApiResponse
    {
        public List<NewsListItem> NewsItems { get; set; }

        public NewsListResponse() : base()
        {
            NewsItems = new List<NewsListItem>();
        }
    }
}
