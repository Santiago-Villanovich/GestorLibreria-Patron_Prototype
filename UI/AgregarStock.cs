using BLL;
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
    public partial class AgregarStock : Form
    {
        public AgregarStock()
        {
            InitializeComponent();
        }

        static Libro _libro;

        private void button1_Click(object sender, EventArgs e)
        {
            if (_libro != null)
            {
                if (numUp.Value > 0)
                {

                }
                else
                {
                    MessageBox.Show("El stock a ingresar debe ser mayor a 0");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ejemplar");
                return;
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _libro = (Libro)dataGridView1.CurrentRow.DataBoundItem;
        }
    }
}
