using System;
using System.Runtime.Serialization;

namespace TobbbformosPizzaAlkalmazasEgyTabla.model
{
    [Serializable]
    internal class ModelMegrendeloNotValidAddressException : Exception
    {
        public ModelMegrendeloNotValidAddressException()
        {
        }

        public ModelMegrendeloNotValidAddressException(string message) : base(message)
        {
        }

        public ModelMegrendeloNotValidAddressException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelMegrendeloNotValidAddressException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}