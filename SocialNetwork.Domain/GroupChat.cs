using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class GroupChat : NamedEntity
    {
        public virtual ICollection<GroupChatUser> GroupChatUsers { get; set; } = new List<GroupChatUser>();
        public virtual ICollection<GroupChatMessage> GroupChatMessages { get; set; } = new List<GroupChatMessage>();
    }
}
