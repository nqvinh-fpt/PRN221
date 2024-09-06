using System;
using System.Collections.Generic;

namespace ClassLibrary.DataAccess
{
    public partial class User
    {
        public User()
        {
            ConversationMembers = new HashSet<ConversationMember>();
            ConversationMessages = new HashSet<ConversationMessage>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<ConversationMember> ConversationMembers { get; set; }
        public virtual ICollection<ConversationMessage> ConversationMessages { get; set; }
    }
}
