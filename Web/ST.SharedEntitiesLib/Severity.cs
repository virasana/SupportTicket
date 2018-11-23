using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ST.SharedEntitiesLib
{
    public partial class Severity
    {
        public Severity()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int SeverityId { get; set; }
        public string DisplayName { get; set; }

        [JsonIgnore] // If needed, you can derive from this class
                     // to create two versions - one will serialise,
                     // and the other will ignore
        public ICollection<Ticket> Tickets { get; set; }
    }
}
