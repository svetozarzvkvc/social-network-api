using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class Role : NamedEntity
    {
        public virtual ICollection<User> Users { get; set; }  = new List<User>();
    }
}
