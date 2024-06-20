using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class Reaction : NamedEntity
    {
        public int FileId { get; set; }
        public virtual File Icon { get; set; }
    }
}
