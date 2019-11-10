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
             FormsAuthentication.SignOut();
         }
         public static int GetUser()
         {
             int user_id = 0;
             //if (HttpContext.Current.User != null)
             //{
                 
             //           FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
             //           if (ticket != null)
             //           {
             //               user_id = Convert.ToInt32(ticket.UserData);
             //           }
                
             //}

            string Token= System.Web.HttpContext.Current.Session["SYSAUTH"] as String; 

            using (var db=new A_Model_proyecto())
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
             //bool persist = true;
             //var cookie = FormsAuthentication.GetAuthCookie("usuario", persist);

             //cookie.Name = FormsAuthentication.FormsCookieName;
             //cookie.Expires = DateTime.Now.AddMonths(3);

             //var ticket = FormsAuthentication.Decrypt(cookie.Value);
             //var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

             //cookie.Value = FormsAuthentication.Encrypt(newTicket);
             //HttpContext.Current.Response.Cookies.Add(cookie);

            string Cadena = Metodos.GenerarCodigo(16);            
            System.Web.HttpContext.Current.Session["SYSAUTH"] = Cadena;

            using ( var db=new A_Model_proyecto())
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
