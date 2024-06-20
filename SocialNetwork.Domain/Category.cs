using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class Category : NamedEntity
    {
        //public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set;} = new HashSet<Category>();
        public virtual ICollection<Post> Posts { get; set;} = new HashSet<Post>();
    }
}
