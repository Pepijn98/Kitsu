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
    
    public class InvalidAuthData : Exception
    {
        public InvalidAuthData() { }

        public InvalidAuthData(string message) : base(message) { }

        public InvalidAuthData(string message, Exception inner) : base(message, inner) { }
        
        public InvalidAuthData(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}