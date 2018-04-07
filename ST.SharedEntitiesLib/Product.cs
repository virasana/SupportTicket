using System.Collections.Generic;

namespace ST.SharedEntitiesLib
{
    public partial class Product
    {
        public Product()
        {
            Ticket = new HashSet<Ticket>();
        }

        public int ProductId { get; set; }
        public string Description { get; set; }

        public ICollection<Ticket> Ticket { get; set; }
    }
}
