using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ST.SharedEntitiesLib
{
    public class Product
    {
        public Product()
        {
            Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Ticket> Tickets { get; set; }
    }
}
