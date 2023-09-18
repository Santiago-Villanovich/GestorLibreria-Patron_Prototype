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
    public class DAL_Editorial
    {
        public DAL_Editorial()
        {
            Odatos = new Acceso();
        }
        Acceso Odatos;

        public bool Crear_Editorial(Editorial oEditorial)
        {
            string consulta = "S_Crear_Editorial";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@nombre",oEditorial.nombre);
            Hdatos.Add("@cuil",oEditorial.cuil);
            Hdatos.Add("@telefono",oEditorial.telefono);
            Hdatos.Add("@direccion",oEditorial.direccion);
            return Odatos.Escribir(consulta, Hdatos);
        }

        public bool Eliminar_Editorial(int ID)
        {
            string consulta = "S_Eliminar_Editorial";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigo", ID);
            return Odatos.Escribir(consulta, Hdatos);
        }

        public List<Editorial> Traer_Editoriales()
        {
            string consulta = "S_Traer_Editoriales";
            Hashtable Hdatos = new Hashtable();
            DataTable DT = Odatos.Leer(consulta, null);
            List<Editorial> Editoriales = new List<Editorial>();
            foreach(DataRow fila in DT.Rows)
            {
                Editorial oEditorial= new Editorial();
                oEditorial.id = Convert.ToInt32(fila["codigo_editorial"]);
                oEditorial.cuil = Convert.ToInt32(fila["cuil"]);
                oEditorial.direccion = fila["direccion"].ToString();
                oEditorial.telefono = fila["telefono"].ToString();
                oEditorial.nombre = fila["nombre"].ToString();
                Editoriales.Add(oEditorial);
            }
            return Editoriales;
        }
}
}
