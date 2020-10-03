using System;
using System.Runtime.Serialization;

namespace WebShopScraper.WebApi.Controllers
{
    [Serializable]
    internal class UnknownProductTypeException : Exception
    {
        public UnknownProductTypeException()
        {
        }

        public UnknownProductTypeException(string message) : base(message)
        {
        }

        public UnknownProductTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownProductTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}