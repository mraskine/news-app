using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NewsApi.Entities
{
    public class GuardianStory
    {
        [Required]
        public string WebTitle { get; set; }
        [Required]
        public string WebUrl { get; set; }
        [Required]
        public string WebPublicationDate { get; set; }
        public Dictionary<string, string> Fields { get; set; }

    }

}
