using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class UserRelation
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public bool? IsAccepted { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime SentAt { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
