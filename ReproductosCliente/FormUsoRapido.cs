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
    public partial class FormUsoRapido : Form
    {
        public FormUsoRapido()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logica cl = new Logica();
            if (cl.verificarForm() == true)  //verifica si existe el FormTimer abierto
            {
                cl.alertaTimerOpen();// alertar que ya esta abierto
            }
            else //de lo contrario va iniciar el timer
            {
                this.Close();
                cl.manipularForm(1); //se miniza todo
                cl.abrirTimer(0); //se abre el timer
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
