using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class Feedback
    {
        public Feedback()
        {
            ExchangeAccessories = new HashSet<ExchangeAccessory>();
            ExchangeCars = new HashSet<ExchangeCar>();
            ExchangeResponses = new HashSet<ExchangeResponse>();
            UserContests = new HashSet<UserContest>();
            UserEvents = new HashSet<UserEvent>();
        }

        public int Id { get; set; }
        public int? FeedbackUserId { get; set; }
        public int? Type { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public int? ReplyUserId { get; set; }
        public string ReplyContent { get; set; }
        public DateTime? ReplyDate { get; set; }

        public virtual User FeedbackUser { get; set; }
        public virtual User ReplyUser { get; set; }
        public virtual ICollection<ExchangeAccessory> ExchangeAccessories { get; set; }
        public virtual ICollection<ExchangeCar> ExchangeCars { get; set; }
        public virtual ICollection<ExchangeResponse> ExchangeResponses { get; set; }
        public virtual ICollection<UserContest> UserContests { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
