using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Fase2.Tags
{
    public class Metodos
    {

        public static string GenerarCodigo(int longi)
        {

            Random obj = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            int longitudnuevacadena = longi;
            string nuevacadena = "";
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[obj.Next(longitud)];
                nuevacadena += letra.ToString();
            }

            return nuevacadena;
        }
      
    }
}