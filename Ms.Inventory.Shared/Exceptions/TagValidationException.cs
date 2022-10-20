using System;
using System.Runtime.Serialization;

namespace Ms.Inventory.Shared.Exceptions
{
    public class TagValidationException : Exception
    {
        public TagValidationException()
        {
        }

        public TagValidationException(string message) : base(message)
        {
        }

        public TagValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TagValidationException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}