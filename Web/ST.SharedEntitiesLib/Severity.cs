using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.SharedEntitiesLib
{
    public partial class Severity
    {
        public Severity()
        {
            Ticket = new HashSet<Ticket>();
        }

        [Key]
        public int SeverityId { get; set; }
        public string DisplayName { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}
