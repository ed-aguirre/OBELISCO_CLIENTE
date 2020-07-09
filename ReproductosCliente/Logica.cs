using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReproductosCliente
{
    class Logica 
    {
        private static Logica logica = null;
        ConectorBD mysql = ConectorBD.getInstancia();

        
        private Dictionary<string, string> programas;
        private Dictionary<string, Object> datosCliente;
        private int detalleID;

        private const byte DESBLOQUEAR_FORM = 1;
        private const byte CERRAR_SESION = 4;
        
        private readonly string EQUIPO = Environment.MachineName;
        private const string TABLA = "computadora";

        private Logica()
        {
            Console.WriteLine("Logica iniciada");
        }

        public static Logica getInstancia()
        {
            if(logica == null)
            {
                logica = new Logica();
            }
            return logica;
        }

        public void setPrgmsEducativos()
        {
            this.programas = mysql.getProgramas();
        }

        public void registrarEquipo()
        {
            int respuesta = mysql.existeMatricula(TABLA, EQUIPO);
            if(respuesta != 1)
            {
                int resp2 = mysql.registrarEquipo(TABLA, EQUIPO);
                if(resp2 == 1)
                {
                    string info = string.Format("El equipo: {0} se ha registrado correctamente.", EQUIPO);
                    new MyMessageBox().Show(info);
                }
                else
                {
                    new MyMessageBox().Show("Al parecer ocurrio un error al registrar el equipo.");
                }
            }
        }

        public bool registrarHistorial(string matricula)
        {
            string hora = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int respuesta = mysql.registrarHistorial(EQUIPO, matricula, hora);
            if(respuesta != 0)
            {
                setIdDetalle(respuesta);
            }
            else
            {
                new MyMessageBox().Show("Ocurrió un problema al intentar registrar el historial.\n" +
                    "Vuelve a intentarlo más tarde");
                return false;
            }
            return true;
        }

        public void updateHistorial()
        {
            string hora = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int respuesta = mysql.updateHistorial(getDetalleId(), hora);
            if( respuesta != 1)
            {
                new MyMessageBox().Show("Se cerró sesión pero ocurrio un problema en el Historial de uso.");
            }

        }

        public void setIdDetalle(int detalleId)
        {
            this.detalleID = detalleId;
        }

        public int getDetalleId()
        {
            return this.detalleID;
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
            string ESTADO;
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
            string FECHA;
            
            if ( DateTime.Compare(fechaExp, fechaActual) < 0  )
            {
                FECHA = "Fecha Expirada";
                mysql.updateEstadoUsuario(consumidor.getIdUsuario());

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
                //fc[0].TopMost = true; // lo pongo en el top
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
                    int respuesta = mysql.updateSaldo(nuevoSaldo,consumidor.getIdUsuario());
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
            //this.consumidor = null;
            this.datosCliente.Clear();
        }

        public void alertaTimerOpen() //solo se usa cuando el timer ya se haya iniciado
        {
            new MyMessageBox().Show("Ya se ha iniciado el cronometro.");
        }

        public void abrirTimer(int tipo, Dictionary<string,Object> datos ) //recibe un entero que sera el tipo de tiemr (1= 3 horas, 0= 3minutos)
        {
            FormTimer time = new FormTimer(tipo, datos);
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
