using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Data;
using System.Collections;
namespace DAL
{
    public class DAL_Libro
    {
        public DAL_Libro()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;

        public bool Guardar_Libro(Libro Olibro)
        {
            string consulta = "S_Crear_Libro";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@cantidad_hojas",Olibro.cantHojas);
            Hdatos.Add("@codigo_editorial",Olibro.editorial.cuil);
            Hdatos.Add("@titulo",Olibro.titulo);
            return oDatos.Escribir(consulta, Hdatos);
        }
        public bool Eliminar_libro(int ID)
        {
            string consulta = "S_Eliminar_Libro";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigo", ID);
            return oDatos.Escribir(consulta, Hdatos);
        }
    }
}
