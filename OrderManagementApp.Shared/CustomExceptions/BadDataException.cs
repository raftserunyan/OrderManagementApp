using System;

namespace OrderManagementApp.Shared.CustomExceptions
{
    public class BadDataException : Exception
    {
        public const string DefaultMessage = "Bad Data";

        public BadDataException(string message = DefaultMessage) : base(message)
        {
        }
    }
}
