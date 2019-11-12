using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using IdentityModel.Client;
using Proyecto_Fase2.Tags;
using Proyecto_Fase2.Models;

namespace Helper
{
     public class SessionHelper
    {

         public static bool ExistUserInSession()
         {

            if ((System.Web.HttpContext.Current.Session["SYSAUTH"] as String) != null)
                return true;
            else
                return false;


         }

         public static void DestroyUserSession()
         {
            
            string Token=System.Web.HttpContext.Current.Session["SYSAUTH"] as String;
           
            if (Token != null) 
            { 
                using (var db = new ModeloProyecto())
                {
                    TokenConnection tk = (from p in db.TokenConnection where p.Token == Token select p).SingleOrDefault();
                    db.TokenConnection.Remove(tk);
                    db.SaveChanges();                

                   
                }
            }
            System.Web.HttpContext.Current.Session["SYSAUTH"] = null;

           
           
        }

        public static int GetUser()
         {
             int user_id = 0;
         

            string Token= System.Web.HttpContext.Current.Session["SYSAUTH"] as String; 

            using (var db=new ModeloProyecto())
            {
                TokenConnection tk = (from p in db.TokenConnection where p.Token == Token select p).SingleOrDefault();

                if (tk!=null)
                {
                    user_id = tk.Id_User;

                }

            }


            return user_id;
         }
         public static void AddUserToSession(string id)
         {
            
            string Cadena = Metodos.GenerarCodigo(16);            
            System.Web.HttpContext.Current.Session["SYSAUTH"] = Cadena;

            using ( var db=new ModeloProyecto())
            {
                TokenConnection tk = new TokenConnection();
                tk.Id_User = int.Parse(id); 
                tk.Token = Cadena;

                db.TokenConnection.Add(tk);
                db.SaveChanges();
            }
          
           


         }

    }
}
