using System;
using System.Runtime.Serialization;

namespace TobbbformosPizzaAlkalmazasEgyTabla.Model
{
    [Serializable]
    internal class ModelMegrendeloNotValidPriceException : Exception
    {
        public ModelMegrendeloNotValidPriceException()
        {
        }

        public ModelMegrendeloNotValidPriceException(string message) : base(message)
        {
        }

        public ModelMegrendeloNotValidPriceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelMegrendeloNotValidPriceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}