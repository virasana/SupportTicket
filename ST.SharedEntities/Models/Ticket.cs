using System.Runtime.Serialization;

namespace ST.SharedEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int TicketId { get; set; }

        public int SeverityId { get; set; }

        [Required, StringLength(1000), DataType(DataType.MultilineText)]
        public string Problem { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Description must be less than 30 characters!")]
        public string Description { get; set; }

        public int ProductId { get; set; }

        public bool Active { get; set; }

        public Product Product { get; set; }

        public Severity Severity { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
