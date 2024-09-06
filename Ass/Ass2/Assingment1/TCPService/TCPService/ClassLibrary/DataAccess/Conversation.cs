using System;
using System.Collections.Generic;

namespace ClassLibrary.DataAccess
{
    public partial class Conversation
    {
        public Conversation()
        {
            ConversationMembers = new HashSet<ConversationMember>();
            ConversationMessages = new HashSet<ConversationMessage>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ConversationMember> ConversationMembers { get; set; }
        public virtual ICollection<ConversationMessage> ConversationMessages { get; set; }
    }
}
