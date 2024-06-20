using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain
{
    public class File : Entity
    {
        public string Path { get; set; }
        public FileType Type { get; set; }
    }

    public enum FileType
    {
        Image,
        Video
    }
}
