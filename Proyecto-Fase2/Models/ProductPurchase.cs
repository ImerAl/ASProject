namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductPurchase")]
    public partial class ProductPurchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPurchase()
        {
            PurcharseDetails = new HashSet<PurcharseDetails>();
        }

        public int Id { get; set; }

        public int? Id_User { get; set; }
        [Display(Name = "Fecha de emision")]
        public DateTime? DateP { get; set; }
        [Display(Name = "Fecha limite")]
        public DateTime? DateLimit { get; set; }

        public int? Id_LatePayment { get; set; }
        [Display(Name = "Estado")]
        [StringLength(1)]
        public string status { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        public virtual LatePayment LatePayment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurcharseDetails> PurcharseDetails { get; set; }

        public virtual Users Users { get; set; }
    }
}
