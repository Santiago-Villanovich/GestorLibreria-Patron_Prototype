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
    public partial class IngresarNuevaEdicion : Form
    {
        public IngresarNuevaEdicion()
        {
            InitializeComponent();
            Dlibro = new DAL_Libro();
            Deditorial = new DAL_Editorial();
            Dautor = new DALautor();
        }
        DAL_Libro Dlibro;
        DAL_Editorial Deditorial;
        DALautor Dautor;

        void LimpiarControles()
        {
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox2.SelectedItem = null;
            cboxAutor.SelectedItem = null;
            numericUpDown1.Value = 0;
            numericUpDown4.Value = 0;
            
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
        }

        void cargardatos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Dlibro.Traer_Libros();

            
            comboBox2.DataSource = Deditorial.Traer_Editoriales();
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "nombre";


            cboxAutor.DataSource = Dautor.Traer_Autores();
            cboxAutor.ValueMember = "codigo";
            cboxAutor.DisplayMember = "apellido";
        }
        private void IngresarNuevaEdicion_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.Libro LibroSelect = (Libro)dataGridView1.CurrentRow.DataBoundItem;

            if (LibroSelect != null)
            {
                BLL.Libro LibroClonado = (BLL.Libro)LibroSelect.ClonProfundo(LibroSelect);
                if (textBox1.Text != string.Empty)
                {
                    LibroClonado.cantHojas = Convert.ToInt32(textBox1.Text);
                }
                if (numericUpDown1.Value != 0)
                {
                    LibroClonado.precio = Convert.ToInt32(numericUpDown1.Value);
                }
                if (dateTimePicker1.Value != null)
                {
                    LibroClonado.anioPubli = dateTimePicker1.Value;
                }
                if (comboBox2.SelectedItem != null)
                {
                    LibroClonado.editorial = (Editorial)comboBox2.SelectedItem;
                }
                if (cboxAutor.SelectedItem != null)
                {
                    LibroClonado.Autor = (autor)cboxAutor.SelectedItem;
                }

                Dlibro.Guardar_Libro(LibroClonado);
                Dautor.guardar_Autor(LibroClonado.Autor);
                Deditorial.Crear_Editorial(LibroClonado.editorial);
                MessageBox.Show("se clono el libro junto a su autor y editorial");
                LimpiarControles();
                cargardatos();
            }
            else
            {
                MessageBox.Show("No selecciono un libro");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BLL.Libro LibroSelect = (Libro)dataGridView1.CurrentRow.DataBoundItem;
            if (LibroSelect != null)
            {
                BLL.Libro LibroClonado = (BLL.Libro)LibroSelect.Clone();
                if (textBox3.Text != string.Empty)
                {
                    LibroClonado.cantHojas = Convert.ToInt32(textBox3.Text);
                }
                if (dateTimePicker2.Value != null)
                {
                    LibroClonado.anioPubli = dateTimePicker2.Value;
                }
                if (numericUpDown4.Value != 0)
                {
                    LibroClonado.precio = Convert.ToInt32(numericUpDown4.Value);
                }
                Dlibro.Guardar_Libro(LibroClonado);
                MessageBox.Show("se clono el libro");
                LimpiarControles();
                cargardatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar algun libro");
            }
        }
    }
}
