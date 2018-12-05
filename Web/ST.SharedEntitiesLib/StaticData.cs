using System;
using System.Collections.Generic;
using System.Text;

namespace ST.SharedEntitiesLib
{
    public class StaticData
    {
        public ICollection<Severity> Severities { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
