namespace Proyecto_Fase2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DPBR")]
    public partial class DPBR
    {
        public int Id { get; set; }

        public int? Id_Role { get; set; }

        public int? Id_Permission { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Role Role { get; set; }
    }
}
