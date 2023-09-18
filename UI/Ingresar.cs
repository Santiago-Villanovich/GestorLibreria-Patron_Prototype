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
using Servicio;
namespace UI
{
    public partial class Ingresar : Form
    {
        public Ingresar()
        {
            InitializeComponent();
            Dusuario = new DAL_usuario();
        }
        DAL_usuario Dusuario;
        private void Ingresar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int error = 0;
            if (textBox1.Text == string.Empty)
            {
                error++;
            }
            if (textBox2.Text == string.Empty)
            {
                error++;
            }
            if (error == 0)
            {
                BLLUsuario Ousuario = new BLLUsuario();
                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;
               Ousuario=  Dusuario.verificar_usuario(usuario, contraseña);
                if (Ousuario != null)
                {
                    SessionManager u = SessionManager.GetInstance;
                    Menu form = new Menu();
                    form.Show();
                    SessionManager.Login(Ousuario);
                   
                }
                else
                {
                    MessageBox.Show("Error al ingresar");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            
        }
    }
}
