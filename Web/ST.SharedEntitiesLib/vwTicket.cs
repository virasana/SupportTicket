using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.SharedEntitiesLib
{
    [Table("vwTicket")]
    public class VwTicket
    {
        [Key]
        public int TicketId { get; set; }

        public int? SeverityId { get; set; }

        public string Problem { get; set; }

        public string Description { get; set; }

        public int? ProductId { get; set; }

        public bool? Active { get; set; }

        public string ProductDescription { get; set; }

        public string Severity { get; set; }
    }
}
