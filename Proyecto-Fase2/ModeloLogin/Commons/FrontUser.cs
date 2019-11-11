using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Proyecto_Fase2.Models;


namespace Proyecto_Fase2.ModeloLogin.Commons
{
    public class FrontUser
    {
        public static bool TienePermiso(RolesPermisos valor)
        {
            
            var usuario = FrontUser.Get();

            if (usuario != null)
            {

                
                    using (var db = new A_Model_proyecto())
                    {
                        string descr = valor.ToString();

                        var permiso = (from c in db.Permission where c.Description == descr select c).Single();

                        if (permiso != null)
                        {
                            var denegado = (from p in db.DPBR where p.Id_Role == usuario.Id_Role && p.Id_Permission== permiso.Id select p).ToList();

                            if (denegado.Count > 0)
                                return false;
                            else
                                return true;
                            
                        }
                        else
                        {
                            return false;
                        }

                    }

               
                  
                
             
            }
            else
            {
                SessionHelper.DestroyUserSession();
                return false;
            }

               
            //return !usuario.Rol.Permiso.Where(x => x.PermisoID == valor)
            //                   .Any();
        }

        public static Users Get()
        {
            return new Users().Obtener(SessionHelper.GetUser());
        }
    }
}