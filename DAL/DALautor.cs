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
            Hdatos.Add("@fechaNacimiento",oAutor.Fecha_Nacimiento);
            return oDatos.Escribir(consulta, Hdatos);

        }

        public bool Eliminar_Autor(autor oAutor)
        {
            string consulta = "S_Eliminar_Autor";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@id", oAutor.codigo);
            return oDatos.Escribir(consulta, Hdatos);
        }

        public List<autor> Traer_Autores()
        {
            string consulta = "S_Traer_Autores";
            DataTable DT = oDatos.Leer(consulta, null);
            List<autor> Autores = new List<autor>();
            foreach(DataRow fila in DT.Rows)
            {
                autor oAutor = new autor();
                oAutor.codigo = Convert.ToInt32(fila["id"]);
                oAutor.nombre = fila["nombre"].ToString();
                oAutor.apellido = fila["apellido"].ToString();
                oAutor.nacionalidad = fila["nacionalidad"].ToString();
                oAutor.Fecha_Nacimiento = Convert.ToDateTime(fila["fecha_nacimiento"]);
                Autores.Add(oAutor);
            }
            return Autores;
        }
}
}