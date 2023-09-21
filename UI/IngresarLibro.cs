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
        DAL_Libro Dlibro;
        DALautor Dautor;
        DAL_Editorial Deditorial;

        void cargarDatos()
        {
            cboxGenero.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxGenero.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboxGenero.DataSource = Dlibro.Traer_Generos();
            cboxGenero.ValueMember = "id";
            cboxGenero.DisplayMember = "descripcion";
            cboxGenero.SelectedItem = null;


        }

        public IngresarLibro()
        {
            InitializeComponent();
            Dlibro = new DAL_Libro();
            Deditorial = new DAL_Editorial();
            Dautor = new DALautor();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int error=0;

            if (error == 0)
            {
               /* autor autorSelect = (autor)dataGridView2.CurrentRow.DataBoundItem;
                Editorial editorialSelect = (Editorial)dataGridView1.CurrentRow.DataBoundItem;*/

                Libro olibro = new Libro();
            //    olibro.editorial = editorialSelect;
                olibro.titulo = textBox1.Text;
                olibro.cantHojas = Convert.ToInt32(textBox2.Text);
                Dlibro.Guardar_Libro(olibro);
                MessageBox.Show("se creo el libro");
                cargarDatos();
            }
        }
        private void IngresarLibro_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          /*  Libro libroSelect = (Libro)dataGridView3.CurrentRow.DataBoundItem;
            autor autorSelect = (autor)dataGridView2.CurrentRow.DataBoundItem;
            Dlibro.Agregar_Autor_al_libro(libroSelect.id, autorSelect.codigo);
            MessageBox.Show("Se asigno correctamente");*/
        }
    }
}
