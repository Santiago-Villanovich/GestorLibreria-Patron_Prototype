using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using BLL;
namespace DAL
{
   public class DALautor
    {
        public DALautor()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;

        public bool guardar_Autor(autor oAutor)
        {
            string consulta = "S_Crear_Autor";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@nombre",oAutor.nombre);
            Hdatos.Add("@apellido",oAutor.apellido);
            Hdatos.Add("@nacionalidad",oAutor.nacionalidad);
            Hdatos.Add("@fecha_nacimiento",oAutor.Fecha_Nacimiento);
            return oDatos.Escribir(consulta, Hdatos);

        }

        public bool Eliminar_Autor(autor oAutor)
        {
            string consulta = "S_Eliminar_Autor";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigo", oAutor.nombre);
            return oDatos.Escribir(consulta, Hdatos);
        }
}
