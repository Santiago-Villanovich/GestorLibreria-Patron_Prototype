using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            CargarMenuContenedor(new IngresarLibro());
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
            Catalogo form = new Catalogo();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IngresarLibro form = new IngresarLibro();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editorial_Autor form = new Editorial_Autor();
            form.Show();
        }
    }
}
