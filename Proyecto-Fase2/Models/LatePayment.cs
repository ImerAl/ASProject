namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LatePayment")]
    public partial class LatePayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LatePayment()
        {
            ProductPurchase = new HashSet<ProductPurchase>();
            SuplyInvoice = new HashSet<SuplyInvoice>();
        }

        public int Id { get; set; }

        public decimal? Increment { get; set; }

        [StringLength(1)]
        public string TypeIncrement { get; set; }

        public int? DaysForIncrement { get; set; }

        public DateTime? LateDayPayment { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPurchase> ProductPurchase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuplyInvoice> SuplyInvoice { get; set; }
    }
}
