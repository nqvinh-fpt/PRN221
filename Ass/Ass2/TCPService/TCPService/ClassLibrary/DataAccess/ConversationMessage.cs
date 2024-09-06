using System;
using System.Collections.Generic;

namespace ClassLibrary.DataAccess
{
    public partial class ConversationMessage
    {
        public Guid ConversationMessageId { get; set; }
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
        public string Message { get; set; } = null!;
        public DateTime TimeSent { get; set; }
        public bool IsFile { get; set; }

        public virtual Conversation Conversation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
