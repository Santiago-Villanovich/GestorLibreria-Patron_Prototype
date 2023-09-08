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
    internal class DAL_Editorial
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
            string consulta = "S_Crear_Editorial";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigo", ID);
            return Odatos.Escribir(consulta, Hdatos);
        }
}
}
