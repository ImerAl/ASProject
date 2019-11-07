namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            SuplyProduct = new HashSet<SuplyProduct>();
        }

        public int Id { get; set; }

        public int? Id_SCP { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(16)]
        public string Internal_Code { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public virtual SubCategory_Provider SubCategory_Provider { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuplyProduct> SuplyProduct { get; set; }
    }
}
