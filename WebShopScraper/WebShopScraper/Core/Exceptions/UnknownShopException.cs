using System;
using System.Runtime.Serialization;

namespace WebShopScraper
{
    [Serializable]
    internal class UnknownShopException : Exception
    {
        public UnknownShopException()
        {
        }

        public UnknownShopException(string message) : base(String.Format("Unknown shop"))
        {
        }

        public UnknownShopException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnknownShopException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}