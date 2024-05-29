using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakenbeheerCore.Errors
{
    [Serializable]
    public class DataConversionException : Exception
    {
        public DataConversionException()
        { 
        
        }

        public DataConversionException(string message) : base(message)
        {

        }

        public DataConversionException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
