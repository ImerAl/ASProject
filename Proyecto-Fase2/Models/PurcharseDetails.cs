namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurcharseDetails
    {
        public int Id { get; set; }

        public int? Id_Purcharse { get; set; }

        public int? Id_SuplyProduct { get; set; }
        [Display(Name = "Cantidad")]
        public int? QuantityBuyed { get; set; }
        [Display(Name = "Total")]
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        public virtual ProductPurchase ProductPurchase { get; set; }

        public virtual SuplyProduct SuplyProduct { get; set; }
    }
}
