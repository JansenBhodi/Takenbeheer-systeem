using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenbeheerCore.Team;

namespace TakenbeheerCore.Errors
{
    [Serializable]
    public class DataNullException : Exception
    {
        public DataNullException() 
        {
        
        }
        public DataNullException(string message) : base(message)
        {

        }

        public DataNullException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
