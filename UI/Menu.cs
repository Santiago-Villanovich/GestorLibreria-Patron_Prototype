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
            CargarMenuContenedor(new Inicio());
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
    }
}
