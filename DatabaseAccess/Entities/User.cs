using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class User
    {
        public User()
        {
            ContestManagers = new HashSet<Contest>();
            ContestModifiedByNavigations = new HashSet<Contest>();
            ContestPrizeManagers = new HashSet<ContestPrize>();
            ContestPrizeUsers = new HashSet<ContestPrize>();
            EventManagers = new HashSet<Event>();
            EventModifiedByNavigations = new HashSet<Event>();
            ExchangeAccessories = new HashSet<ExchangeAccessory>();
            ExchangeCars = new HashSet<ExchangeCar>();
            ExchangeResponses = new HashSet<ExchangeResponse>();
            FeedbackFeedbackUsers = new HashSet<Feedback>();
            FeedbackReplyUsers = new HashSet<Feedback>();
            ProposalManagers = new HashSet<Proposal>();
            ProposalUsers = new HashSet<Proposal>();
            UserContests = new HashSet<UserContest>();
            UserEvents = new HashSet<UserEvent>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string TokenWeb { get; set; }
        public string TokenMobile { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? ExchangePost { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Contest> ContestManagers { get; set; }
        public virtual ICollection<Contest> ContestModifiedByNavigations { get; set; }
        public virtual ICollection<ContestPrize> ContestPrizeManagers { get; set; }
        public virtual ICollection<ContestPrize> ContestPrizeUsers { get; set; }
        public virtual ICollection<Event> EventManagers { get; set; }
        public virtual ICollection<Event> EventModifiedByNavigations { get; set; }
        public virtual ICollection<ExchangeAccessory> ExchangeAccessories { get; set; }
        public virtual ICollection<ExchangeCar> ExchangeCars { get; set; }
        public virtual ICollection<ExchangeResponse> ExchangeResponses { get; set; }
        public virtual ICollection<Feedback> FeedbackFeedbackUsers { get; set; }
        public virtual ICollection<Feedback> FeedbackReplyUsers { get; set; }
        public virtual ICollection<Proposal> ProposalManagers { get; set; }
        public virtual ICollection<Proposal> ProposalUsers { get; set; }
        public virtual ICollection<UserContest> UserContests { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
