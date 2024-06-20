using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.DTO
{
    public class CategoriesSearch : PagedSearch
    {
        public string Keyword { get; set; }
    }

    public class SearchCategoriesResult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Posts { get; set; }
    }
}
