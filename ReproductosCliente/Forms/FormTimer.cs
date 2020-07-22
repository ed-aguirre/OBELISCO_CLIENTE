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
    public partial class FormTimer : Form
    {
        Logica logica = Logica.getInstancia();
        private IConsumidor consumidor;
        private int segundos = 60;
        private int minutos = 0;
        private int horas = 0;

        private const byte MODO_RAPIDO = 0;
        private const byte MODO_USAR_PC = 1;
        private int MODO_RECIBIDO;

        private const byte BLOQUEAR_FORM = 0;
        private const byte ALERTA_MODO_RAPIDO = 3;
        private const byte ALERTA_MODO_USAR_PC = 2;
        public FormTimer(int modo, Dictionary<string, Object> datosCliente)
        {
            this.consumidor = Consumidor.FromMap(datosCliente);
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedToolWindow; // este es una ventanita pero se puede cerrar
            TopMost = true;
            this.ControlBox = false;
            MODO_RECIBIDO = modo;
            inicio(MODO_RECIBIDO);// si es tipo 1, se iniciara con 3 horas, else seran 3 minutos

        }
        public void inicio(int modo) //metodo que inicia el timer
        {
            if(modo == MODO_USAR_PC)
            {
                minutos = 60;
                horas = 2;
            }
            else
            {
                minutos = 3;
            }
            lblSegundo.Text = segundos.ToString();
            lblMinuto.Text = valorTimer(minutos);
            lblHora.Text = valorTimer(horas);
            tmr.Start();
            
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if( horas == 0 && minutos== 0 && segundos == 0)
            {
                tmr.Enabled = false;
                tiempoAgotado(MODO_RECIBIDO);
                this.Close(); //nose si comentar esta linea hmmm
                
            }

            if (segundos == 0)
            {
                if (minutos == 0)
                {
                    minutos = 60;
                    horas--;
                    lblHora.Text = valorTimer(horas);
                    
                }
                segundos = 60;
            }

            if ( segundos == 60)
            {
                if(minutos == 60)
                {
                    horas--;
                    lblHora.Text = valorTimer(horas);
                }
                minutos--;
                lblMinuto.Text = valorTimer(minutos);
            }

            segundos--;
            lblSegundo.Text = valorTimer(segundos);
            
        }

        private void tiempoAgotado(int modo)
        {

            if (modo == MODO_RAPIDO) // el tiempo rapido, Salir del programa
            {
                logica.manipularForm(BLOQUEAR_FORM);
                //maximiza y bloquea. siento que necesito acceder al bloqeuar form directo del principal
                new MyMessageBox().Show(ALERTA_MODO_RAPIDO);

                forzarCerrarSesion(); // manipula el form1 y cierra sesión

            }
            else //el tiempo de 2 horas
            {
                logica.manipularForm(BLOQUEAR_FORM); //se maximiza el form y lo bloquea.
                DialogResult continuar = new MyMessageBox().Show(ALERTA_MODO_USAR_PC); //se envia la alerta del tiempo excedido
                if(continuar == DialogResult.Yes) 
                {
                    new MyMessageBox().Show("No olvides cerrar sesión cuando termines.");
                }
                else
                {
                    forzarCerrarSesion();// manipula el form1 y cierra sesión
                }
            }
        }

        private String valorTimer(int valorHora)
        {
            if(valorHora.ToString().Length < 2)
            {
                return "0" + valorHora;
            }
            else
            {
                return valorHora.ToString();
            }
        }

        private void forzarCerrarSesion()
        {
            FormPrincipal.ActiveForm.Focus(); //hace focus al form principal
            for (int i = 0; i < 4; i++)//hace cuatro tabs para llegar al boton de cerrar sesión
            {
                SendKeys.Send("{TAB}");
            }

            SendKeys.Send("{ENTER}"); SendKeys.Send("{ENTER}");
            //hace dos enter para confirmar o, mas bien, forzar el cierre de sesión
        }

        private void FormTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }
            if (e.CloseReason == CloseReason.TaskManagerClosing)
            {
                if (consumidor.getTipoUsuario() == 1)
                {
                    e.Cancel = true;
                    return;
                    //e.Cancel = true; //NO SE CIERRA
                }
            }*/
            tmr.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
