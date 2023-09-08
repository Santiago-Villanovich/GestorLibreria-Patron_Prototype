using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using BLL;
namespace DAL
{
   public class DAL_usuario
    {
        public DAL_usuario()
        {
            oBLLusuario = new BLLUsuario();
            Odatos = new Datos();
        }
        BLLUsuario oBLLusuario;
        Datos Odatos;

        public bool Guardar_Usuario(BLLUsuario Usuario)
        {
            string consulta = "S_Crear_Usuario";

            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@username",Usuario.username);
            Hdatos.Add("@contraseña",Usuario.contraseña);
            Hdatos.Add("@DNI",Usuario.DNI);
            return Odatos.Escribir(consulta, Hdatos);
        }

        public BLLUsuario verificar_usuario(string username,string contraseña)
        {
            string consulta = "S_Verificar_Usuario";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@username",username);
            Hdatos.Add("@contraseña",contraseña);
            DataTable DT = Odatos.Leer(consulta, Hdatos);
            BLLUsuario usuario = new BLLUsuario();
            foreach (DataRow fila in DT.Rows)
            {
                if (DT.Rows.Count > 0)
                {
                    
                    usuario.username = fila["username"].ToString();
                    usuario.contraseña = fila["contraseña"].ToString();
                    usuario.DNI = Convert.ToInt32(fila["DNI"]);
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
