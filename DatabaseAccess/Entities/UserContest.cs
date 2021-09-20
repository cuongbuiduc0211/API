using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class UserContest
    {
        public int Id { get; set; }
        public int? ContestId { get; set; }
        public int? UserId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? Status { get; set; }
        public int? Evaluation { get; set; }
        public int? FeedbackId { get; set; }

        public virtual Contest Contest { get; set; }
        public virtual Feedback Feedback { get; set; }
        public virtual User User { get; set; }
    }
}
