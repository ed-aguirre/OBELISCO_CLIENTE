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
        Logica logica;
        private IConsumidor consumidor;
        private const byte INICIAR_TIMER = 1;
        private const byte DESBLOQUEAR_FORM = 1;
        public FormUsarPC()
        {
            InitializeComponent();
        }

        public FormUsarPC(Dictionary<string,Object> datosUsuario)
        {
            InitializeComponent();
            this.consumidor = Consumidor.FromMap(datosUsuario);
        }

        private void btnAceptarUsar_Click(object sender, EventArgs e)
        {
            logica = new Logica();
            if (logica.verificarForm())  //si existe el FormTimer abierto
            {
                logica.alertaTimerOpen();// alertar que ya esta abierto
            }
            else //iniciar timer
            {
                if (logica.saldoSuficiente(consumidor))
                {
                    this.Close();
                    logica.manipularForm(DESBLOQUEAR_FORM);// se minimizaTodo
                    logica.abrirTimer(INICIAR_TIMER); //se inicia el timer
                }
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
