namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Provider")]
    public partial class Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provider()
        {
            SubCategory_Provider = new HashSet<SubCategory_Provider>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string NIT { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCategory_Provider> SubCategory_Provider { get; set; }
    }
}
