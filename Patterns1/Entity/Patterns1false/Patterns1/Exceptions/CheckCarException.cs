using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns1.Exceptions
{
    public class CheckCarException : Exception
    {
        public CheckCarException() : base("Some problems with car")
        { }
    }
}
