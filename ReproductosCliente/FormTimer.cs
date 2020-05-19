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
        public int segundos = 60;
        public int minutos = 0;
        public int horas = 0;
        public int tipoInicio = 0;
        public FormTimer(int tipo)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            inicio(tipo);// si es tipo 1, se iniciara con 3 horas, else seran 3 minutos

        }
        public void inicio(int tipo) //metodo que inicia el timer
        {
            if(tipo == 1)
            {
                minutos = 60;
                horas = 2;
            }
            else
            {
                minutos = 3;//CAMBIAR A 3
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
                tiempoAgotado(0);
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

        private void tiempoAgotado(int tipoInicio)
        {
            Class1 cl = new Class1();
            if(tipoInicio == 0) // el tiempo rapido, entonces tendrá que salir del programa
            {
                cl.manipularForm(0); //se maximiza el form y lo bloquea.
                cl.alerta(3); //se envia la alerta del tiempo excedido

                forzarCerrarSesion(); // manipula el form1 y cierra sesión

            }
            else //el tiempo de 2 horas, por lo que tiene que preguntar si desea continuar
            {
                cl.manipularForm(0); //se maximiza el form y lo bloquea.
                int continuar = cl.alerta(2); //se envia la alerta del tiempo excedido
                if(continuar == 1) //si le da yes, se cobrará 3$ y se reiniciará el contador
                {
                    //ya se
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
            Form1.ActiveForm.Focus(); //hace focus al form principal
            for (int i = 0; i < 4; i++)//hace cuatro tabs para llegar al boton de cerrar sesión
            {
                SendKeys.Send("{TAB}");
            }

            SendKeys.Send("{ENTER}"); SendKeys.Send("{ENTER}");
            //hace dos enter para confirmar o, mas bien, forzar el cierre de sesión
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmr.Enabled = false;
        }
    }
}
