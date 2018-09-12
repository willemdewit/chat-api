using System;
using JsonApiDotNetCore.Models;

namespace chatApi.Models
{
    public class Message : Identifiable
    {
        [Attr("message")]
        public string _Message { get; set; }

        public int ConversationId { get; set; }

        [HasOne("conversation")]
        public virtual Conversation Conversation { get; set; }

        public int ParticipantId { get; set; }

        [HasOne("participant")]
        public virtual Participant Participant { get; set; }

        [Attr("sent-date-time")]
        public DateTime SentDateTime { get; set; }
    }
}