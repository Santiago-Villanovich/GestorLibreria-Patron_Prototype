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
    public partial class Editorial_Autor : Form
    {
        public Editorial_Autor()
        {
            InitializeComponent();
            Dautor = new DALautor();
            Deditorial = new DAL_Editorial();
            cargar_Datos();
        }
        DALautor Dautor;
        DAL_Editorial Deditorial;
        private void Editorial_Autor_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }
        void cargar_Datos()
        {
            List<Editorial> Editoriales = Deditorial.Traer_Editoriales();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Editoriales;
            //Crear lista de autores y trerlo de SQL
            List<autor> autores = Dautor.Traer_Autores();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = autores;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (error == 0)
            {
                Editorial Oeditorial = new Editorial(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text);
                Deditorial.Crear_Editorial(Oeditorial);
                MessageBox.Show("se creo la editorial");
                cargar_Datos();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (error == 0)
            {
                Editorial editorialSelect =(Editorial)dataGridView1.CurrentRow.DataBoundItem;
                Deditorial.Eliminar_Editorial(editorialSelect.id);
                cargar_Datos();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (error == 0)
            {
                BLL.autor Oautor = new BLL.autor();
                Oautor.nombre = textBox5.Text;
                Oautor.apellido = textBox6.Text;
                Oautor.nacionalidad = textBox7.Text;
                Oautor.Fecha_Nacimiento = dateTimePicker1.Value;
                Dautor.guardar_Autor(Oautor);
                MessageBox.Show("Se creo al autor");
                cargar_Datos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            BLL.autor autorSelect = (autor)dataGridView2.CurrentRow.DataBoundItem;
            if (autorSelect != null)
            {
                Dautor.Eliminar_Autor(autorSelect);
                MessageBox.Show("Se elimino al autor");
                cargar_Datos();
            }
            else
            {
                MessageBox.Show("debe seleccionar a un autor primero");
            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
    }
}
