using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Errors
{
    [Serializable]
    public class DatabaseHandlerException : Exception
    {

        public DatabaseHandlerException()
        {

        }

        public DatabaseHandlerException(string message) : base(message)
        {

        }

        public DatabaseHandlerException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
