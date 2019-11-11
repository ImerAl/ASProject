namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int Id { get; set; }

        public int? Id_User { get; set; }

        public int? Id_Area { get; set; }

        [StringLength(1)]
        public string Chief_Area { get; set; }

        public virtual Area Area { get; set; }

        public virtual Users Users { get; set; }
    }
}
