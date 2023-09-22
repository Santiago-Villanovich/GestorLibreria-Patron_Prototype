using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;
using BLL;

namespace UI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void CargarMenuContenedor(object formHijo)
        {
            if (this.ContPanel.Controls.Count > 0)
            {
                this.ContPanel.Controls.RemoveAt(0);
            }
            Form frm = formHijo as Form;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            this.ContPanel.Controls.Add(frm);
            this.ContPanel.Tag = frm;
            frm.Show();
        }
       
        private void ContPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Catalogo());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new IngresarLibro());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new Editorial_Autor());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            Ingresar form = new Ingresar();
            form.Show();
            this.Hide();
        }

        private void btnAgregarStock_Click(object sender, EventArgs e)
        {
            CargarMenuContenedor(new AgregarStock());
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            CargarMenuContenedor(new IngresarNuevaEdicion());
        }
    }
}
