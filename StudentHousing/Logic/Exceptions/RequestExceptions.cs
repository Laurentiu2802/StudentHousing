using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class RequestExceptions : Exception
    {
        public RequestExceptions() { }

        public RequestExceptions(string? message) : base(message) { }

        public RequestExceptions(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
