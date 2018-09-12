using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace chatApi.Models
{
    public class ConversationParticipant : Identifiable
    {
        public int ConversationId { get; set; }

        [HasOne("conversation")]
        public virtual Conversation Conversation { get; set; }

        public int ParticipantId { get; set; }

        [HasOne("participant")]
        public virtual Participant Participant { get; set; }
    }
}