namespace Proyecto_Fase2.Models
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
   
    
    
    

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Phone = new HashSet<Phone>();
            ProductPurchase = new HashSet<ProductPurchase>();
        }

        public int Id { get; set; }

        public int? Id_Role { get; set; }
        [Display(Name = "Credenciales")]
        [StringLength(50)]
        public string Credentials { get; set; }
        [Display(Name = "Contraseña")]
        [StringLength(255)]
        public string Password { get; set; }
        [Display(Name = "Primer Nombre")]
        [StringLength(15)]
        public string Name1 { get; set; }
        [Display(Name = "Segundo Nombre")]
        [StringLength(15)]
        public string Name2 { get; set; }
        [Display(Name = "Primer Apellido")]
        [StringLength(15)]
        public string LName1 { get; set; }
        [Display(Name = "Segundo Apellido")]
        [StringLength(15)]
        public string LName2 { get; set; }
        [Display(Name = "Imagen")]
        [StringLength(255)]
        public string Picture { get; set; }
       
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phone> Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPurchase> ProductPurchase { get; set; }

        public virtual Role Role { get; set; }


        public ResponseModel Autenticarse()
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new A_Model_proyecto())
                {
                    var usuario = ctx.Users.Where(x => x.Email == this.Email && x.Password == this.Password).SingleOrDefault();

                    if (usuario != null )
                    {
                        SessionHelper.AddUserToSession(usuario.Id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false);
                    }
                }
            }
            catch
            {
                throw;
            }
            return rm;
        }

        public Users Obtener(int id)
        {
            var usuario = new Users();

            try
            {
                using (var ctx = new A_Model_proyecto())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    usuario = ctx.Users.Where(x => x.Id == id).SingleOrDefault();
                }
            }
            catch
            {
                throw;
            }

            return usuario;
        }





    }
}
