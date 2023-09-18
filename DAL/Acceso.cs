using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
namespace DAL
{
   public class Acceso
    {
        public SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-0Q8ML9D\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True");

        private SqlTransaction tranx;

        public SqlCommand comando;

        public bool Escribir(string consulta, Hashtable Hdatos)
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            tranx = conexion.BeginTransaction();
            comando = new SqlCommand(consulta, conexion, tranx);
            comando.CommandType = CommandType.StoredProcedure;


            if (Hdatos != null)
            {
                foreach (string dato in Hdatos.Keys)
                {
                    comando.Parameters.AddWithValue(dato, Hdatos[dato]);
                }
            }
            int respuesta = comando.ExecuteNonQuery();
            tranx.Commit();
            return true;
        }

        public DataTable Leer(string consulta, Hashtable Hdatos)
        {

            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }

            DataTable DT = new DataTable();
            comando = new SqlCommand(consulta, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter DA;
            DA = new SqlDataAdapter(comando);//consulta, conexion);
            if (Hdatos != null)
            {
                foreach (string dato in Hdatos.Keys)
                {
                    comando.Parameters.AddWithValue(dato, Hdatos[dato]);
                }
            }
            DA.Fill(DT);
            return DT;
        }
    }
}
