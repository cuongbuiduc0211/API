using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseAccess.Entities
{
    public partial class ContestPrize
    {
        public int Id { get; set; }
        public int? ContestId { get; set; }
        public int? PrizeId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ManagerId { get; set; }

        public virtual Contest Contest { get; set; }
        public virtual User Manager { get; set; }
        public virtual Prize Prize { get; set; }
        public virtual User User { get; set; }
    }
}
