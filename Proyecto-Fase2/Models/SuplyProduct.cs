namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuplyProduct")]
    public partial class SuplyProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuplyProduct()
        {
            PurcharseDetails = new HashSet<PurcharseDetails>();
        }

        public int Id { get; set; }

        public int? Id_SuplyInvoice { get; set; }

        public int? Id_Product { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurcharseDetails> PurcharseDetails { get; set; }

        public virtual SuplyInvoice SuplyInvoice { get; set; }
    }
}
