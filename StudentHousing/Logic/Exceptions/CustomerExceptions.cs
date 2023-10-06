using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Exceptions
{
    public class CustomerExceptions : Exception
    {
        public CustomerExceptions() { }

        public CustomerExceptions(string? message) : base(message) { }

        public CustomerExceptions(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
