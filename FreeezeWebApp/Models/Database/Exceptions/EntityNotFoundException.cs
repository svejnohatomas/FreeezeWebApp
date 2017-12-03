using System;

namespace FreeezeWebApp.Models.Database.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base()
        {

        }
        public EntityNotFoundException(string message) : base(message)
        {

        }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public EntityNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }
    }
}