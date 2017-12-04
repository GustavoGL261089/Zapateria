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
    public partial class frmusuarionew : Form
    {
        public frmusuarionew()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre, clave, tipo;
            if (textBox1.Text.CompareTo("") == 0 || textBox2.Text.CompareTo("") == 0 || textBox3.Text.CompareTo("") == 0 || comboBox1.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Existen campos vacios por rellenar");
            }
            else{

                nombre = textBox1.Text;
                clave = textBox2.Text;
                tipo = comboBox1.Text;

                if (textBox3.Text.CompareTo(clave) != 0)
                {
                    MessageBox.Show("La contraseña introducida no coincide al confirmar");
                }
                else
                {

                    Conexion conexion = new Conexion();
                    conexion.insertar_usuario(nombre, clave, tipo);
                }
            }
        }
    }
}
