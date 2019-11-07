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

        public int? QuantityBuyed { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        public virtual ProductPurchase ProductPurchase { get; set; }

        public virtual SuplyProduct SuplyProduct { get; set; }
    }
}
