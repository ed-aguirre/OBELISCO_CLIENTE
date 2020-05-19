using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductosCliente
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            
            InitializeComponent();
            getTODO();
            Console.WriteLine( new dataCliente().getName() );
        }

        public void getTODO()
        {
            dataCliente dc = new dataCliente();
            lblNombre.Text = dc.getName();
            lblApellidos.Text = dc.getApellido();
            lblCarrera.Text = dc.getCarrera();
            lblMatricula.Text = dc.getMatricula();
            lblSaldo.Text = dc.getSaldo().ToString();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            //inservibleeeee
        }
    }
}
