using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReproductosCliente
{
    class Logica 
    {
        private IConsumidor consumidor;
        private Dictionary<string, string> programas;
        private Dictionary<string, Object> datosCliente;

        private const byte DESBLOQUEAR_FORM = 1;
        private const byte CERRAR_SESION = 4;
        private string ESTADO;
        private string FECHA ;

        public Logica()
        {
            Console.WriteLine("Logica iniciada");
        }

        public void setPrgmsEducativos()
        {
            this.programas = new ConectorBD().getProgramas();
        }
        public Dictionary<string,string> getPrgmsEducativo()
        {
            return programas;
        }

        public void setDatosCliente(Dictionary<string, Object> datos)
        {
            datosCliente = datos;
        }
        public Dictionary<string, Object> getDatosCliente()
        {
            return datosCliente;
        }

        public Boolean ValidarTipoUsuario(IConsumidor consumidor)
        {
            if(ValidarEstadoUsuario(consumidor) || ValidarFechaExpiracion(consumidor))
            {
                //si alguno da true, no puede acceder
                return false; 
            }
            return true;
        }

        private Boolean ValidarEstadoUsuario(IConsumidor consumidor)
        {
            if (consumidor.getEstadoUsuario() != 2)
            {
                ESTADO = Consumidor.nombrarTipoEstado(consumidor.getEstadoUsuario());
                new MyMessageBox().
                    Show(ESTADO + "\nTu usuario no tiene permitido entrar al sistema.");
                return true;
            }
            return false;
        }
        private Boolean ValidarFechaExpiracion(IConsumidor consumidor)
        {
            DateTime fechaExp = consumidor.getFechaExpiracion();
            DateTime fechaActual = DateTime.Now;

            if ( DateTime.Compare(fechaExp, fechaActual) < 0  )
            {
                FECHA = "Fecha Expirada";
                new ConectorBD().updateEstadoUsuario(consumidor.getIdUsuario());

                new MyMessageBox().
                    Show(FECHA + "\nTu usuario no tiene permitido entrar al sistema.");
                return true;
            }
            return false;
        }
        
        public void manipularForm(int bloqueo) //recibe 1 si se quiere desbloquer(minizar) y 0 si se quiere bloquear el form1
        {
            FormCollection fc = Application.OpenForms; //crear coleccion de Forms
            
            if(bloqueo == DESBLOQUEAR_FORM)
            {
                fc[0].FormBorderStyle = FormBorderStyle.Sizable;
                //quitar esta linea de arriba al final!!
                fc[0].TopMost = false; // lo quito del top
                fc[0].WindowState = FormWindowState.Minimized; //y se minimiza
                //en la posición 0 porque es el primer form de la coleccion
                
            }
            else
            {
                fc[0].FormBorderStyle = FormBorderStyle.None; //hago el form principal no sea manejable
                fc[0].TopMost = true; // lo pongo en el top
                fc[0].WindowState = FormWindowState.Maximized; //y se maximiza
            }

        }

        public Boolean saldoSuficiente(IConsumidor consumidor)
        {
            float nuevoSaldo = consumidor.getSaldo() - 3;

            if ( nuevoSaldo >= 0)
            {
                string alerta = string.Format("Despues de la operación tu saldo disponible será de:\n" +
                    "$ {0}\n" +
                    "¿Deseas continuar?", nuevoSaldo);
                DialogResult result = new MyMessageBox().Show(alerta);

                if(result == DialogResult.OK)
                {
                    consumidor.setSaldo(nuevoSaldo);
                    int respuesta = new ConectorBD().updateSaldo(nuevoSaldo,consumidor.getIdUsuario());
                    if(respuesta == 1)
                    {
                        return true;
                    }
                    else
                    {
                        new MyMessageBox().Show();// error
                    }
                }
            }
            else
            {
                new MyMessageBox().Show("Saldo insuficiente.");
            }
            return false;
        }


        public Boolean cerrarSesion()
        {
            DialogResult result = new MyMessageBox().Show(CERRAR_SESION);
            if ( result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        public void vaciarDatosUsuario()
        {
            this.consumidor = null;
            this.datosCliente.Clear();
        }

        public void alertaTimerOpen() //solo se usa cuando el timer ya se haya iniciado
        {
            new MyMessageBox().Show("Ya se ha iniciado el cronometro.");
        }

        public void abrirTimer(int tipo) //recibe un entero que sera el tipo de tiemr (1= 3 horas, 0= 3minutos)
        {
            FormTimer time = new FormTimer(tipo);
            time.Show();
        }

        public bool verificarForm()//verifica si el formTimer esta ejecutandose
        {
            bool existe = false;
            foreach(Form frm in Application.OpenForms)
            {
                
                if(frm.Name.Equals("FormTimer"))
                {
                    existe = true;
                }
            }
            return existe;
        }


    }
}
