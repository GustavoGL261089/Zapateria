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
    public partial class frmnueva_compra : Form
    {
        
        Lista lista;
        Lista tem;

        public frmnueva_compra()
        {
            InitializeComponent();
            lista = null;

        }

        public string obtenerFecha()
        {
            DateTime fecha = new DateTime();
            string day = fecha.Day.ToString();
            string month = fecha.Month.ToString();
            string year = fecha.Year.ToString();

            string fecha_final = year + "/" + month + "/" + day;

            return fecha_final;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id=0;
            string marca, color, modelo;
            int precio, cantidad, descuento;
            float talla;
            /*
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Lleno");
            }
            else
            {
                MessageBox.Show("Vacio");
            } */

            marca = textBox6.Text;
            color = textBox3.Text;
            modelo = textBox2.Text;
            precio = Convert.ToInt32(textBox5.Text);
            talla = Convert.ToSingle(textBox4.Text);
            cantidad = Convert.ToInt32(textBox7.Text);
            descuento = Convert.ToInt32(textBox8.Text);
            if (lista == null)
            {
                lista = new Lista(id, marca, modelo, color, precio, cantidad, descuento, talla);
            }
            else
            {
                tem = new Lista(id, marca, modelo, color, precio, cantidad, descuento, talla);
                tem.next = lista;
                lista = tem;
            }

            contar_articulo();
            borrar();
                       
        }

        public void borrar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        public void contar_articulo()
        {
            tem = lista;
            int contador=0;
            int subtotal = 0;
            int descuento = 0;
            while(tem!=null)
            {
                contador += tem.cantidad;
                subtotal += (tem.cantidad * tem.precio);
                descuento += tem.descuento;
                tem = tem.next;
            }

            label12.Text = "" + contador;
            label13.Text = "" + subtotal;
            label15.Text = "$ " + (subtotal-descuento);
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta=MessageBox.Show("Al salir de esta ventana se perderan todos los datos de la compra, ¿Está seguro que desea eliminar toda la compra?","Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmventa_completa fnuevo = new frmventa_completa(lista);
            fnuevo.Show();
        }


    }


}
