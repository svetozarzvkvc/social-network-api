using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Exceptions
{
    public class ForeignKeyConstraintException : Exception
    {
        public ForeignKeyConstraintException(string message):base(message)
        {
            
        }
    }
}