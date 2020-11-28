using System;

namespace WebShopScraper.Models
{
    public class BaseParser
    {
        public event EventHandler Stop;
        protected virtual void OnZeroProductsParsed(EventArgs args)
        {
            EventHandler handler = Stop;
            handler?.Invoke(this, args);
        }
    }
}