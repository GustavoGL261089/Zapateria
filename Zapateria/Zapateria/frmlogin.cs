using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zapateria
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre, clave;
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Existen campos vacios por rellenar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                nombre = textBox1.Text;
                clave = textBox2.Text;
                Conexion con = new Conexion();

                if (con.sesion(nombre, clave).CompareTo("invalido") == 0)
                {
                    MessageBox.Show("Tu nombre de usuario o contraseña son incorrectos","Incorrecto", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (con.sesion(nombre, clave).CompareTo("Vendedor") == 0)
                    {
                        MessageBox.Show("Bienvenido Vendedor", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (con.sesion(nombre, clave).CompareTo("Administrador") == 0)
                    {
                        MessageBox.Show("Bienvenido Administrador", "Aceptado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    frmmenu f2 = new frmmenu();

                    this.Hide();
                    f2.ShowDialog();
                    this.Close();

                }
            }
        }


    }
}
