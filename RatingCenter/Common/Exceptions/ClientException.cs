using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ClientException: Exception
    {
        public ClientException(string message) : base(message)
        {

        }
    }
}
