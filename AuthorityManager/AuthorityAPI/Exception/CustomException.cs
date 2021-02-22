using System;

namespace AuthorityAPI
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
}