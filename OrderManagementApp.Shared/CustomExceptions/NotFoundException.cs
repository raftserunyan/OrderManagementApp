using System;

namespace OrderManagementApp.Shared.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public const string DefaultMessage = "Not found";

        public NotFoundException(string message = DefaultMessage) : base(message)
        {
        }
    }
}
