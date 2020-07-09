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
        Logica logica = Logica.getInstancia();
        private Dictionary<string, Object> datosCliente;
        private const byte INICIAR_TIMER = 1;
        private const byte DESBLOQUEAR_FORM = 1;
        public FormUsarPC()
        {
            InitializeComponent();
        }

        public FormUsarPC(Dictionary<string,Object> datosUsuario)
        {
            InitializeComponent();
            this.datosCliente = datosUsuario;
        }

        private void btnAceptarUsar_Click(object sender, EventArgs e)
        {
            IConsumidor consumidor = Consumidor.FromMap(datosCliente);

            if (logica.verificarForm())  //si existe el FormTimer abierto
            {
                logica.alertaTimerOpen();// alertar que ya esta abierto
            }
            else //iniciar timer
            {
                if (logica.saldoSuficiente(consumidor) && logica.registrarHistorial(consumidor.getIdUsuario()))
                {
                    this.Close();
                    logica.manipularForm(DESBLOQUEAR_FORM);// se minimizaTodo
                    logica.abrirTimer(INICIAR_TIMER, datosCliente); //se inicia el timer
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
