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
    public partial class IngresarLibro : Form
    {
        public IngresarLibro()
        {
            InitializeComponent();
            Dlibro = new DAL_Libro();
            Deditorial = new DAL_Editorial();
            Dautor = new DALautor();
            cargarDatos();
        }
        DAL_Libro Dlibro;
        DALautor Dautor;
        DAL_Editorial Deditorial;
        private void button1_Click(object sender, EventArgs e)
        {
            int error=0;

            if (error == 0)
            {
                autor autorSelect = (autor)dataGridView2.CurrentRow.DataBoundItem;
                Editorial editorialSelect = (Editorial)dataGridView1.CurrentRow.DataBoundItem;

                Libro olibro = new Libro();
                olibro.editorial = editorialSelect;
                olibro.titulo = textBox1.Text;
                olibro.cantHojas = Convert.ToInt32(textBox2.Text);
                Dlibro.Guardar_Libro(olibro);
                MessageBox.Show("se creo el libro");
                cargarDatos();
            }
        }

        void cargarDatos()
        {
            List<BLL.Editorial> Editoriales = Deditorial.Traer_Editoriales();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Editoriales;
            List<autor> autores = Dautor.Traer_Autores();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = autores;
            List<Libro> Libros = Dlibro.Traer_Libros();
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = Libros;
        }

        private void IngresarLibro_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Libro libroSelect = (Libro)dataGridView3.CurrentRow.DataBoundItem;
            autor autorSelect = (autor)dataGridView2.CurrentRow.DataBoundItem;
            Dlibro.Agregar_Autor_al_libro(libroSelect.id, autorSelect.codigo);
            MessageBox.Show("Se asigno correctamente");
        }
    }
}
