using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;


namespace UI
{
    public partial class Catalogo : Form
    {
        private DAL_Libro DALibro;
        private DAL_Editorial DALEditorial;
       
        public Catalogo()
        {
            InitializeComponent();
            DALibro = new DAL_Libro();
            DALEditorial = new DAL_Editorial();
        }
        Libro oLibroT;
        Libro oLibroG;
        BLL.Editorial editorial;

        private void CargarCBoxs()
        {
            cboxTitulo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxTitulo.AutoCompleteSource = AutoCompleteSource.ListItems;

            List<Libro> list = DALibro.Traer_Libros();
            cboxTitulo.DataSource = list; 
            cboxTitulo.ValueMember = "id";
            cboxTitulo.DisplayMember = "titulo";

            cboxTitulo.SelectedItem = null;

            ///////////////////////////////////////////////////////////////////////
            cboxGenero.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxGenero.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboxGenero.DataSource = list;
            cboxGenero.ValueMember = "id";
            cboxGenero.DisplayMember = "genero";

            cboxGenero.SelectedItem = null;

            /////////////////////////////////////////////////////////////////////////
            cboxEditorial.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxEditorial.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboxEditorial.DataSource = DALEditorial.Traer_Editoriales();
            cboxEditorial.ValueMember = "id";
            cboxEditorial.DisplayMember = "nombre";

            cboxEditorial.SelectedItem = null;
        }
        void cargar_Libros()
        {
         
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DALibro.Traer_Libros_Filtered(oLibroT.titulo,oLibroG.genero,editorial.nombre);
        }
        private void Catalogo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DALibro.Traer_Libros_Filtered(null,null,null);

            CargarCBoxs();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* if (cboxTitulo.SelectedValue != null)
             {
                titulo = cboxTitulo.SelectedItem.ToString();
             }
             if (cboxGenero.SelectedValue != null)
             {
                 genero = cboxGenero.SelectedItem.ToString();
             }
             if (cboxEditorial.SelectedValue != null)
             {
                  editorial = cboxEditorial.SelectedItem.ToString();
             }*/

            cargar_Libros();
        }

        private void cboxTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTitulo.SelectedItem != null)
            {
               oLibroT  = (Libro)cboxTitulo.SelectedItem;
            }
           
        }

        private void cboxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxGenero.SelectedItem != null)
            {
                oLibroG = (Libro)cboxGenero.SelectedItem;
            }
            
        }

        private void cboxEditorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxEditorial.SelectedItem != null)
            {
                editorial = (BLL.Editorial)cboxEditorial.SelectedItem;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oLibroG = null;
            oLibroT = null;
            editorial = null;
            cargar_Libros();
        }
    }
}
