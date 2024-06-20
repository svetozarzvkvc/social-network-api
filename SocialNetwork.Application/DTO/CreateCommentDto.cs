using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.DTO
{
    public class CreateCommentDto
    {
        public int AuthorId { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int? ParentId { get; set; }
    }
}
