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
    public partial class frminventario : Form
    {
        Lista lis;

        public frminventario()
        {
            InitializeComponent();
            Lista tem;
            int i = 0;
            Conexion con=new Conexion();
            tem = con.obten_inventario();
            lis = tem;
            while (tem != null)
            {
                this.dataGridView1.Rows.Insert(i,tem.id, tem.marca, tem.modelo, tem.color, tem.talla, tem.cantidad,tem.precio);
                tem = tem.next;
                i++;
            }
            this.dataGridView1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta=MessageBox.Show("¿Está seguro que desea eliminar el registro?","Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                int id = 0;

                id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                Conexion con = new Conexion();
                con.eliminar_registro(id, "zapatos", "idzapatos");
                this.dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                MessageBox.Show("Se elimino el zapato " + id);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            { //aqui se define la columna que se quiere aplicar formato

                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                decimal valor = 0;

                if (decimal.TryParse(cell.Value.ToString(), out valor))
                {

                    cell.Value = valor.ToString("N1");

                }
                else
                {
                    cell.Value=0.0;
                    MessageBox.Show("La celda talla no acepta el valor asignado, ingrese un valor correcto", "Precausion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dataGridView1.CurrentCell = this.dataGridView1.CurrentCell;
                }

            }
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            { //aqui se define la columna que se quiere aplicar formato

                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                decimal valor = 0;

                if (decimal.TryParse(cell.Value.ToString(), out valor))
                {

                    cell.Value = valor.ToString("N0");

                }
                else
                {
                    cell.Value = 0.0;
                    MessageBox.Show("La celda no acepta el valor asignado, ingrese un valor correcto", "Precausion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.dataGridView1.CurrentCell = this.dataGridView1.CurrentCell;
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Está seguro que desea modificar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                int id = 0;
                int cantidad = 0;
                int precio = 0;
                float talla = 0;
                string modelo = "", color = "";

                id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
                cantidad = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[5].Value);
                precio = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[6].Value);
                talla = Convert.ToSingle(this.dataGridView1.CurrentRow.Cells[4].Value);
                modelo = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
                color = Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value);
               

                Conexion con = new Conexion();
                con.modificarzapato(id,cantidad,modelo,color,talla,precio);
                MessageBox.Show("Se modifico el zapato " + id);
            }
        }
    }
}
