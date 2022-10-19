using System.ComponentModel.DataAnnotations;


namespace NewsApi.Entities
{
    public class NewsListItem
    {
        [Required]
        public string WebTitle { get; set; }
        [Required]
        public string WebUrl { get; set; }
        [Required]
        public string WebPublicationDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
