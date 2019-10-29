namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuplyInvoice")]
    public partial class SuplyInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuplyInvoice()
        {
            SuplyProduct = new HashSet<SuplyProduct>();
        }

        public int Id { get; set; }

        public int? Id_AccountingBook { get; set; }

        public int? Id_LatePayment { get; set; }
        [Display(Name = "Fecha de compra")]
        public DateTime? Date_Suply { get; set; }
        [Display(Name = "Total final")]
        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "Estado")]
        [StringLength(1)]
        public string status { get; set; }

        public virtual AccoutingBook AccoutingBook { get; set; }

        public virtual LatePayment LatePayment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuplyProduct> SuplyProduct { get; set; }
    }
}
