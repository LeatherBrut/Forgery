﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forgery.Providers
{
    public class ProviderException : Exception
    {
        public ProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ProviderException()
        {
        }

        public ProviderException(string message) : base(message)
        {
        }
    }
}
