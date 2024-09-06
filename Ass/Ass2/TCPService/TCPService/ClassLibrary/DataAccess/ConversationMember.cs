using System;
using System.Collections.Generic;

namespace ClassLibrary.DataAccess
{
    public partial class ConversationMember
    {
        public Guid ConversationMemberId { get; set; }
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }

        public virtual Conversation Conversation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
