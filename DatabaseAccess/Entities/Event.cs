using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class Event
    {
        public Event()
        {
            UserEvents = new HashSet<UserEvent>();
        }

        public int Id { get; set; }
        public int ManagerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string Image { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public DateTime StartRegister { get; set; }
        public DateTime EndRegister { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CurrentParticipants { get; set; }
        public int? Rating { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ProposalId { get; set; }

        public virtual User Manager { get; set; }
        public virtual User ModifiedByNavigation { get; set; }
        public virtual Proposal Proposal { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
