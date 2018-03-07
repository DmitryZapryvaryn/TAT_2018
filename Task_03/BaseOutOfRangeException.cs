using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class BaseOutOfRangeException : Exception
    {

        private string errMessage = "Number's base is out of range.";

        public BaseOutOfRangeException()
        {
        }

        public BaseOutOfRangeException(string message)
            : base(message)
        {
        }

        public BaseOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string Message
        {
            get
            {
                return errMessage;
            }
        }
    }
}
