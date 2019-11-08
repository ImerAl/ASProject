namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CxC30
    {
        public int Id { get; set; }

        public int? Id_User { get; set; }

        public DateTime? DateP { get; set; }

        public DateTime? DateLimit { get; set; }

        public int? Id_LatePayment { get; set; }

        [StringLength(1)]
        public string status { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalAmount { get; set; }
    }
}
