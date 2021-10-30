using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEHAD
{
    class Exceptionoutofarray: Exception
    {
        public Exceptionoutofarray(string Message) :base(Message)
        {
        }
    }
}
