using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class EventItem
    {
        public string Creater { get; set; }
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
        public string Editor { get; set; }
        public int ProposalId { get; set; }
    }
}
