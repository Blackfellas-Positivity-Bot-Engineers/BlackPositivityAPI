using System;

namespace BlackPositivity.Domain.Models
{
    public class BlackPositivityQuote
    {
        public Guid ID { get; set; }
        public string Contributor { get; set; }
        public string Quote { get; set; }
        public bool hasBeenUsed { get; set; }
        public DateTime DateAdded { get; set; }
    }
}