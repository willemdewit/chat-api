using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace chatApi.Models
{
    public class Conversation : Identifiable
    {
        [Attr("subject")]
        public string Subject { get; set; }
        
        [Attr("is-complete")]
        public bool IsComplete { get; set; }

        [HasMany("messages")]
        public virtual List<Message> Messages { get; set; }
    }
}