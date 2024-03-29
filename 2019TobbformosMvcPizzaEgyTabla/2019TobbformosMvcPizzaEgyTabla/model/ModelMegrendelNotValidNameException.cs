﻿using System;
using System.Runtime.Serialization;

namespace TobbbformosPizzaAlkalmazasEgyTabla.model
{
    [Serializable]
    internal class ModelMegrendeloNotValidNameException : Exception
    {
        public ModelMegrendeloNotValidNameException()
        {
        }

        public ModelMegrendeloNotValidNameException(string message) : base(message)
        {
        }

        public ModelMegrendeloNotValidNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModelMegrendeloNotValidNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}