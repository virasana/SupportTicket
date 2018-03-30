namespace ST.SharedEntities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Severity")]
    public partial class Severity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Severity()
        {
        }

        public int SeverityId { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }
    }
}
