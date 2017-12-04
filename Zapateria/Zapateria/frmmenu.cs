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
    public partial class frmmenu : Form
    {
        public frmmenu()
        {
            InitializeComponent();
        }

       private void button7_Click(object sender, EventArgs e)
        {
            frmnueva_compra fnuevo = new frmnueva_compra();
            fnuevo.Show();
        }

       private void button3_Click(object sender, EventArgs e)
       {
           frmalta_zapatos fnuevo = new frmalta_zapatos();
           fnuevo.Show();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           frminventario fnuevo = new frminventario();
           fnuevo.Show();
       }

       private void button5_Click(object sender, EventArgs e)
       {
           frmusuarionew fnuevo = new frmusuarionew();
           fnuevo.Show();
       }

        
    }
}
