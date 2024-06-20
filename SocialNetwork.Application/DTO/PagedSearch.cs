using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.DTO
{
    public class PagedSearch
    {
        public int? PerPage { get; set; } = 1;
        public int? Page { get; set; } = 1;
    }
}
