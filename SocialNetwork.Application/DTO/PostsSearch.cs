using SocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.DTO
{
    public class PostsSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Username { get; set; }
        public bool? HasComments { get; set; }
    }


    public class SearchPostResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }

        public string Author { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        public int CommentsCount { get; set; }
        public IEnumerable<PostSearchCommentsDto> Comments { get; set; }
    }

    public class PostSearchCommentsDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorUserName { get; set; }
        public DateTime Time { get; set; }
    }
}
