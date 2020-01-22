using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Core.Domain.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string message)
        : base(message)
        {
        }

        public ModelException(string message, Exception inner)
            : base(message, inner)
        {
        }

        
    }
}
