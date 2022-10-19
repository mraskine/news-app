using System;

namespace NewsApi.Entities
{
    public class NewsStory
    {
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
        public DateTime WebPublicationDate { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }        

    }
}
