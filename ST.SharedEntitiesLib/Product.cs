using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ST.SharedEntitiesLib
{
    public partial class Product
    {
        public Product()
        {
            Ticket = new HashSet<Ticket>();
        }
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}
