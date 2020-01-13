using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Exceptions
{
    class IdentificationException : Exception
    {
        public IdentificationException(string message) : base(message)
        {

        }
    }
}
