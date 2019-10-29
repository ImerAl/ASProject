namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubCategory_Provider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubCategory_Provider()
        {
            Product = new HashSet<Product>();
        }
        [Display(Name = "Proveedor(Subcategoria)")]
        public int Id { get; set; }

        public int? Id_SCategory { get; set; }
        
        public int? Id_Provider { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }

        public virtual Provider Provider { get; set; }

        public virtual Sub_Category Sub_Category { get; set; }
    }
}
