using System.Collections.Generic;

namespace Bargain.Services.Common
{
    public class Error
    {
        public List<string> Messages { get; set; }
        
        public Error(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public Error(string message)
        {
            Messages = new List<string>();

            if (!string.IsNullOrWhiteSpace(message))
            {
                Messages.Add(message);
            }
        }
    }
}