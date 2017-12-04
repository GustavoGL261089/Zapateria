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
    public partial class frmalta_zapatos : Form
    {
        public frmalta_zapatos()
        {
            InitializeComponent();
            Conexion con = new Conexion();
            List<string> marcas = new List<string>();
            marcas = con.obtener_marcas();
            foreach (string m in marcas)
            {
                comboBox1.Items.Add(m);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id, cantidad, marca, modelo, color, talla, precio;
           
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Existen campos vacios por rellenar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                id = textBox1.Text;
                cantidad = textBox6.Text;
                marca = comboBox1.Text;
                modelo = textBox3.Text;
                color = textBox2.Text;
                talla = textBox4.Text;
                precio = textBox5.Text;

                Conexion conexion = new Conexion();
                conexion.insertar_zapato(Convert.ToInt32(cantidad), marca, modelo, color, Convert.ToSingle(talla), Convert.ToInt32(precio));

            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) { 
                e.Handled = true; 
                return; 
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox4.Text.Length; i++)
            {
                if (textBox4.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 1)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show(" ¿No desea dar de alta otro zapato?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            comboBox1.Text = con.obten_marca(textBox1.Text);
        }


       
    }
}
