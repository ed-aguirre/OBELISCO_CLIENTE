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
    public partial class FormUsarPC : Form
    {
        public FormUsarPC()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptarUsar_Click(object sender, EventArgs e)
        {
            Class1 cl = new Class1();
            if (cl.verificarForm() == true)  //verifica si existe el FormTimer abierto
            {
                cl.alertaTimerOpen();// alertar que ya esta abierto
            }
            else //de lo contrario va iniciar el timer
            {
                this.Close();
                cl.manipularForm(1);// se minimizaTodo
                cl.abrirTimer(1); //se inicia el timer
            }

        }
    }
}
