using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.SharedEntities.Models
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
