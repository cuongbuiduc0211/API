using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class ExchangeCar
    {
        public ExchangeCar()
        {
            ExchangeCarDetails = new HashSet<ExchangeCarDetail>();
            ExchangeResponses = new HashSet<ExchangeResponse>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int? FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ExchangeCarDetail> ExchangeCarDetails { get; set; }
        public virtual ICollection<ExchangeResponse> ExchangeResponses { get; set; }
    }
}
