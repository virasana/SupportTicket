using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.SharedEntitiesLib
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        public int SeverityId { get; set; }
        public string Problem { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public bool Active { get; set; }
        public byte[] TimeStamp { get; set; }

        public Product Product { get; set; }
        public Severity Severity { get; set; }
    }
}
