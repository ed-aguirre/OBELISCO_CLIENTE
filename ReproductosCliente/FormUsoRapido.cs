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
        Logica logica = Logica.getInstancia();
        private Dictionary<string, Object> datosCliente;
        private const byte DESBLOQUEAR_FORM = 1;
        private const byte MODO_RAPIDO = 0;
        public FormUsoRapido()
        {
            InitializeComponent();
        }
        public FormUsoRapido(Dictionary<string, Object> datosUsuario)
        {
            InitializeComponent();
            this.datosCliente = datosUsuario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IConsumidor consumidor = Consumidor.FromMap(datosCliente);

            if (logica.verificarForm())  //verifica FormTimer abierto
            {
                logica.alertaTimerOpen();
            }
            else // inicia el timer
            {
                if (logica.registrarHistorial(consumidor.getIdUsuario()))
                {
                    this.Close();
                    logica.manipularForm(DESBLOQUEAR_FORM); //se miniza todo
                    logica.abrirTimer(MODO_RAPIDO, datosCliente); //se abre el timer
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
