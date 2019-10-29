namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phone")]
    public partial class Phone
    {
        public int Id { get; set; }

        public int? Id_User { get; set; }

        [StringLength(15)]
        public string Number_Phone { get; set; }

        public virtual Users Users { get; set; }
    }
}
