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
      
        public bool Agregar_Autor_al_libro(int IDlibro,int IDautor)
        {
            string consulta = "S_Asignar_Autor_a_Libro";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigoLibro",IDlibro);
            Hdatos.Add("@codigoAutor",IDautor);
            return oDatos.Escribir(consulta, Hdatos);
        }
        public bool Guardar_Libro(Libro Olibro)
        {
            string consulta = "S_Crear_Libro";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@cantidad_hojas",Olibro.cantHojas);
            Hdatos.Add("@codigo_editorial",Olibro.editorial.cuil);
            Hdatos.Add("@titulo",Olibro.titulo);
            Hdatos.Add("@idGenero",Olibro.genero.id);
            Hdatos.Add("@fechaPublicacion",Olibro.anioPubli);
            Hdatos.Add("@precio",Olibro.precio);
            return oDatos.Escribir(consulta, Hdatos);
        }
        public bool Eliminar_libro(int ID)
        {
            string consulta = "S_Eliminar_Libro";
            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigo", ID);
            return oDatos.Escribir(consulta, Hdatos);
        }

        public List<Libro> Traer_Libros()
        {
            string consulta = "S_Traer_Libros";
            DataTable DT = oDatos.Leer(consulta, null);
            List<Libro> Libros = new List<Libro>();
            foreach(DataRow fila in DT.Rows)
            {
                Libro oLibro = new Libro();
                oLibro.id = Convert.ToInt32(fila["codigoLibro"]);
                oLibro.titulo = fila["titulo"].ToString();
                oLibro.cantHojas= Convert.ToInt32(fila["cantidad_hojas"]);
                oLibro.anioPubli = Convert.ToDateTime(fila["fecha_publicacion"]);
                oLibro.precio = Convert.ToInt32(fila["precio"]);
                ////////////////////////////////////////////////////////////////////////////////////corregir esta parte,colgue que era uno a muchos,mala mia

                Genero oGenero = new Genero();
                oGenero.id = Convert.ToInt32(fila["id"]);
                oGenero.descripcion = fila["descripcion"].ToString();
                ////////////////////////////////////////////////////////////////////////////////////

                Editorial oEditorial = new Editorial();
                oEditorial.id= Convert.ToInt32(fila["codigo_editorial"]);
                oEditorial.cuil= Convert.ToInt32(fila["cuil"]);
                oEditorial.direccion= fila["direccion"].ToString();
                //     oEditorial.telefono= fila["telefono"].ToString();

                autor oAutor = new autor();
                oAutor.codigo = Convert.ToInt32(fila["Codigo_autor"]);
                oAutor.nombre = fila["nombre"].ToString();
                oAutor.apellido = fila["apellido"].ToString();
                oAutor.nacionalidad = fila["nacionalidad"].ToString();
                oAutor.Fecha_Nacimiento = Convert.ToDateTime(fila["fecha_nacimiento"]);

                oLibro.Autor = oAutor;
                oLibro.genero = oGenero;
                oLibro.editorial = oEditorial;
               // oLibro.autores = Traer_Autores(oLibro.id);
                Libros.Add(oLibro);
            }
            return Libros;
        }

        public List<Libro> Traer_Libros_Filtered(string titulo, string genero, string NombreEditorial)
        {
            string consulta = "S_Traer_Libros_Filtro";
            Hashtable Hdatos = new Hashtable();
                Hdatos.Add("@titulo", titulo == null ? (object)DBNull.Value : titulo);
               Hdatos.Add("@genero", genero == null ? (object)DBNull.Value : genero);
             Hdatos.Add("@NombreEditorial", NombreEditorial == null ? (object)DBNull.Value : NombreEditorial);
            DataTable DT = oDatos.Leer(consulta,Hdatos);
            List<Libro> Libros = new List<Libro>();
            foreach (DataRow fila in DT.Rows)
            {
                Libro oLibro = new Libro()
                {
                    id = Convert.ToInt32(fila["codigoLibro"]),
                    titulo = fila["titulo"].ToString(),
                    cantHojas = Convert.ToInt32(fila["cantidad_hojas"]),

                    editorial = new Editorial()
                    {
                        id = Convert.ToInt32(fila["codigo_editorial"]),
                        cuil = Convert.ToInt32(fila["cuil"]),
                        direccion = fila["direccion"].ToString()
                    },

                    genero = new Genero()
                    {
                        id = Convert.ToInt32(fila["id"]),
                        descripcion = fila["descripcion"].ToString()
                    },
                    Autor = new autor()
                    {
                        codigo = Convert.ToInt32(fila["id_autor"]),
                        nombre = fila["nombre"].ToString(),
                        apellido=fila["apellido"].ToString(),
                        nacionalidad=fila["nacionalidad"].ToString(),
                        Fecha_Nacimiento=Convert.ToDateTime(fila["fecha_nacimiento"])
                    },
                };

                //oLibro.autores = Traer_Autores(oLibro.id);
                Libros.Add(oLibro);
            }
            return Libros;
        }

     /*   public List<autor> Traer_Autores(int ID)
        {
            string consulta = "S_Traer_Autores_Libro";

            Hashtable Hdatos = new Hashtable();
            Hdatos.Add("@codigoLibro", ID);
            DataTable DT = oDatos.Leer(consulta, Hdatos);
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
        }*/

        public List<Genero> Traer_Generos()
        {
            string consulta = "S_Traer_Autores_Libro";

            Hashtable Hdatos = new Hashtable();
            DataTable DT = oDatos.Leer(consulta, Hdatos);
            List<Genero> generos= new List<Genero>();
            foreach (DataRow fila in DT.Rows)
            {
                Genero oGenero = new Genero();
                oGenero.id = Convert.ToInt32(fila["id"]);
                oGenero.descripcion = fila["descripcion"].ToString();
                generos.Add(oGenero);
                //generos.Add(oAutor);
            }
            return generos;
        }

    }

    
}
