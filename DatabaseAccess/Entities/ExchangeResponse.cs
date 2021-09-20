using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class ExchangeResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public int? ExchangeCarId { get; set; }
        public int? ExchangeAccessoryId { get; set; }
        public int? FeedbackId { get; set; }

        public virtual ExchangeAccessory ExchangeAccessory { get; set; }
        public virtual ExchangeCar ExchangeCar { get; set; }
        public virtual Feedback Feedback { get; set; }
        public virtual User User { get; set; }
    }
}
