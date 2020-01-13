using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Exceptions
{
    public class LiftException : Exception
    {
        public LiftException(string message) : base(message)
        { }
    }
}
