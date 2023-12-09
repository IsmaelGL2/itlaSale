using System;
using System.Collections.Generic;
using System.Text;

namespace Sale.Application.Exceptions
{
    public class UsuarioServiceException : Exception
    {
        public UsuarioServiceException(string message) : base(message)
        {

        }
    }
}
