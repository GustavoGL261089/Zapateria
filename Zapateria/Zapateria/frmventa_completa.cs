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
    public partial class frmventa_completa : Form
    {
        public frmventa_completa(Lista lista)
        {
            InitializeComponent();
            Lista tem;
            int i = 0;

            tem = lista;
            while (tem != null)
            {
                this.dataGridView1.Rows.Insert(i, tem.marca, tem.modelo, tem.talla, tem.color, tem.precio, tem.cantidad, tem.descuento);
                tem = tem.next;
                i++;
            }
            this.dataGridView1.CurrentCell = null;
        }

    }
}
