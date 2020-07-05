﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReproductosCliente
{
    class Logica 
    {
        private IConsumidor consumidor;
        private Dictionary<string, string> programas;
        private Dictionary<string, Object> datosCliente;

        private const int BLOQUEAR_FORM = 1;
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
                new MyMessageBox().
                    Show(FECHA + "\nTu usuario no tiene permitido entrar al sistema.");
                return true;
            }
            return false;
        }
        public void manipularForm(int bloqueo) //recibe 1 si se quiere desbloquer(minizar) y 0 si se quiere bloquear el form1
        {
            FormCollection fc = Application.OpenForms; //crear coleccion de Forms
            
            if(bloqueo == BLOQUEAR_FORM)
            {
                fc[0].FormBorderStyle = FormBorderStyle.Sizable; //hago el form principal manejable
                //quitar esta linea de arriba al final!!
                fc[0].TopMost = false; // lo quito del top
                fc[0].WindowState = FormWindowState.Minimized; //y se miniza
                //en la posición 0 porque es el primer form de la coleccion
                
            }
            else
            {
                fc[0].FormBorderStyle = FormBorderStyle.None; //hago el form principal no sea manejable
                fc[0].TopMost = true; // lo pongo en el top
                fc[0].WindowState = FormWindowState.Maximized; //y se maximiza
            }


        }

        public int alerta(int tipo) 
            //hay tipos de alertas (1= alerta de cerraSesion, 2= alerta de tiempo)
        {
            String titulo = "";
            String texto = "";
            MessageBoxButtons boton = MessageBoxButtons.OK;
            switch (tipo)
            {
                case 1: //cuando sea uno sera el caso de CerrarSesion
                    titulo = "Cerrar Sesión";
                    texto = "¿Deseas cerrar sesión?";
                    boton = MessageBoxButtons.YesNo;
                    break;
                case 2: //cuando sea 2 será el caso de Tiempo excedido
                    titulo = "Tiempo excedido";
                    texto = "Tu tiempo se ha agotado, ¿deseas seguir utilizando el equipo?";
                    boton = MessageBoxButtons.YesNo;
                    break;
                case 3: //3: el tiempo agotado del tiempo rápido
                    titulo = "Tiempo excedido";
                    texto = "Tu tiempo se ha agotado. Se cerrará la sesión.";
                    boton = MessageBoxButtons.OK;
                    break;
                case 4: //4: alerta de registro completado
                    titulo = "Registro realizado";
                    texto = "Ve con el Administrador para completar el registro. No olvides llevar tu credencial UV.";
                    boton = MessageBoxButtons.OK;
                    break;
                default:
                    Console.WriteLine("No hay default");
                    break;
            }

            DialogResult r = MessageBox.Show(texto, titulo, boton);
            //crea un objeto de DialogResult y guarda el valor que el usuario seleccione
            if( r == DialogResult.Yes || r == DialogResult.OK)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public void alertaTimerOpen() //solo se usa cuando el timer ya se haya iniciado
        {
            MessageBox.Show("Ya se ha iniciado el cronometro.", "Tiempo iniciado", MessageBoxButtons.OK);
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
