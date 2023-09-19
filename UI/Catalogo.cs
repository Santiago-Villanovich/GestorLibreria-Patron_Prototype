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

        private void Catalogo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DALibro.Traer_Libros();

            CargarCBoxs();
            
        }
    }
}
