using System;
using System.Runtime.Serialization;

namespace Kitsu
{
    public class NoDataFoundException : Exception
    {
        public NoDataFoundException() { }

        public NoDataFoundException(string message) : base(message) { }

        public NoDataFoundException(string message, Exception inner) : base(message, inner) { }
        
        public NoDataFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}