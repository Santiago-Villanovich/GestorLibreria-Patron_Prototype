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

            cboxAutor.DataSource = Dautor.Traer_Autores();
            cboxAutor.ValueMember = "codigo";
            cboxAutor.DisplayMember = "NombreCompleto";
            cboxAutor.SelectedItem = null;

            cboxEditorial.DataSource = Deditorial.Traer_Editoriales();
            cboxEditorial.ValueMember = "id";
            cboxEditorial.DisplayMember = "nombre";
            cboxEditorial.SelectedItem = null;
        }

        void LimpiarControles()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            cboxAutor.SelectedItem = null;
            cboxEditorial.SelectedItem = null;
            cboxGenero.SelectedItem = null;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
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
            try
            {
                Libro olibro = new Libro();

                olibro.titulo = textBox1.Text;
                olibro.cantHojas = Convert.ToInt32(textBox2.Text);
                olibro.genero = (Genero)cboxGenero.SelectedItem;
                olibro.Autor = (autor)cboxAutor.SelectedItem;
                olibro.editorial = (Editorial)cboxEditorial.SelectedItem;
                olibro.precio = Convert.ToInt32(numericUpDown2.Value);
                olibro.anioPubli = dateTimePicker1.Value;
                olibro.stock = Convert.ToInt32(numericUpDown1.Value);

                Dlibro.Guardar_Libro(olibro);

                MessageBox.Show("Libro registrado con exito");

                IngresarLibro_Load(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void IngresarLibro_Load(object sender, EventArgs e)
        {
            LimpiarControles();
            cargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
