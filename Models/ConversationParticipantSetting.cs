using System;
using System.Collections.Generic;
using JsonApiDotNetCore.Models;

namespace chatApi.Models
{
    public class ConversationParticipantSetting : Identifiable
    {
        [Attr("last-read-date-time")]
        public DateTime lastReadDateTime { get; set; }

        public int ConversationParticipantId { get; set; }

        [HasOne("conversation-participant")]
        public virtual ConversationParticipant ConversationParticipant { get; set; }

    }
}