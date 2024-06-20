using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class PostFile
    {
        public int PostId { get; set; }
        public int FileId { get; set; }
        public virtual Post Post { get; set; }
        public virtual File File { get; set; }
    }
}
