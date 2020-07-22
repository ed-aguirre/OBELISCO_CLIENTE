using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReproductosCliente
{
    
    public partial class FormPrincipal : Form
    {
        FormRegistro FR;
        FormLogin FL;
        FormCliente FC;
        FormUsarPC FPC;
        FormUsoRapido FUR;
        Logica logica = Logica.getInstancia();

        private const byte REGISTRO_EXITO = 1;
        private const byte REGISTRO_SIN_EXITO = 0;

        private const byte VISTA_ARRANQUE = 1;
        private const byte VISTA_CONSUMIDOR = 0;

        private const byte MOSTRAR_BTN_REGISTRARSE = 0;
        private const byte MOSTRAR_BTN_INGRESAR = 1;

        private const byte LOGIN_EXITO = 5;

        public FormPrincipal()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            Colorear_panel();
            customDesing(VISTA_ARRANQUE);
            inicio();
            
        }

        private void inicio()
        {
            if( !File.Exists("config.txt"))
            {
                new MyMessageBox().Show("Es la primera vez que se inicia el programa en este equipo.\n" +
                    "Iniciando proceso de configuracion.");
                FormConfig config = new FormConfig();
                config.Show();
            }
            else
            {
                bloquearForm();
                logica.conectarBD();
            }
        }
        private void Colorear_panel() //pinta el panel lateral
        {
            panelBase.BackColor = ColorTranslator.FromHtml("#005baa");
            subPanel1.BackColor = ColorTranslator.FromHtml("#005baa");
            subPanel2.BackColor = ColorTranslator.FromHtml("#005baa");
            panel1.BackColor = ColorTranslator.FromHtml("#005baa");
            btnApagar.BackColor = ColorTranslator.FromHtml("#005baa");

            this.ShowIcon = false;
            this.ShowInTaskbar = false;
        }

        private void customDesing(int casoInicio)// inicia y setea los valores de los paneles principales
        {
            if(casoInicio == VISTA_ARRANQUE)
            {
                subPanel1.Visible = false;//Y VUELVE INVISIBLE EL PRIMER PANEL
                btnIngresar.Visible = false;
                btnRegistrarse.Visible = false;
                btnBack.Visible = false;
                btnApagar.Visible = true;
            }
            else if(casoInicio == VISTA_CONSUMIDOR) 
            {
                cambioMenu(); //cambio la vista de los submenus principales
                btnIngresar.Visible = false; //vuelve invisible a los botones de login
                btnRegistrarse.Visible = false;
                btnBack.Visible = false;
                btnApagar.Visible = false;

                btnRegistrar.BackColor = Color.CornflowerBlue;//regresa a los colores originales:)
                btnIniciarSesion.BackColor = Color.CornflowerBlue;
            }
            
        }

        public void cambioMenu()//cambia la visibilidad de los paneles cuando selecciona login o registrar
        {
            if(subPanel2.Visible)
            {
                subPanel2.Visible = false;
                subPanel1.Visible = true;
                
            }
            else if (subPanel1.Visible)
            {
                subPanel1.Visible = false;
                subPanel2.Visible = true;
                btnApagar.Visible = true;
            }
            
        }

        public void cambioBotones(int boton)
        {
            btnBack.Visible = true;
            btnApagar.Visible = false;
            if(boton == MOSTRAR_BTN_REGISTRARSE)
            {
                btnRegistrar.BackColor = Color.LightSteelBlue;//cambia los colores
                btnIniciarSesion.BackColor = Color.CornflowerBlue;

                btnIngresar.Visible = false;//cambia la visibilidad
                btnRegistrarse.Visible = true;
            }
            else if( boton == MOSTRAR_BTN_INGRESAR)
            {
                btnIniciarSesion.BackColor = Color.LightSteelBlue;//cambia lo colores
                btnRegistrar.BackColor = Color.CornflowerBlue;

                btnRegistrarse.Visible = false;//cambia la visibilidad
                btnIngresar.Visible = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FL = new FormLogin();
            abrirChildForm(FL);//se crea el objeto formLogin y se pasa como parametro
            cambioBotones( MOSTRAR_BTN_INGRESAR ); //se envia un parametro uno, para indicar al metodo que es login
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FR = new FormRegistro(logica.getPrgmsEducativo()) ;
            abrirChildForm(FR);
            cambioBotones(MOSTRAR_BTN_REGISTRARSE);
        }
        private void btnIngresar_Click(object sender, EventArgs e) //este es el que manda datos al dataCliente
        {
            if (FL.validarCampos())
            {

                logica.setDatosCliente(FL.iniciarSesion());
                if(logica.getDatosCliente().Count > 0)
                {
                    if ( logica.ValidarTipoUsuario( logica.getDatosCliente() )) //true == pasa
                    {
                        //new MyMessageBox().Show(LOGIN_EXITO);
                        if( logica.getPrgmsEducativo() != null) //evita el error de nullPointerException
                        {
                            FC = new FormCliente(logica.getDatosCliente(), logica.getPrgmsEducativo());
                        }
                        else
                        {
                            FC = new FormCliente(logica.getDatosCliente());
                        }
                        
                        abrirChildForm(FC);
                        customDesing(VISTA_CONSUMIDOR);
                    }

                }
            }

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            activeForm.Close(); //cierra cualquier form activo
            customDesing(VISTA_ARRANQUE);//regresa a la vista de Arranque

            btnRegistrar.BackColor = Color.CornflowerBlue;//regresa a los colores originales:)
            btnIniciarSesion.BackColor = Color.CornflowerBlue;
        }

        private Form activeForm = null;
        private void abrirChildForm(Form childForm)//cambio de formularios
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            FC = new FormCliente(logica.getDatosCliente(), logica.getPrgmsEducativo());
            abrirChildForm(FC);
        }

        private void btnUsarPC_Click(object sender, EventArgs e)
        {
            FPC = new FormUsarPC( logica.getDatosCliente() );
            abrirChildForm( FPC );
        }

        private void btnUsoRapido_Click(object sender, EventArgs e)
        {
            FUR = new FormUsoRapido( logica.getDatosCliente() );
            abrirChildForm(FUR);
        }

        public void bloquearForm() //bloquea el form1 para que el usuario no pueda manipularlo
        { 
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            //ESTA LINEA DE CODIGO ES IMPORTANTE, 
            
        }


        private void btnRegistrarAccion_Click(object sender, EventArgs e)//boton RegistrarAccion
        {
            int respuesta = 0;
            if(FR.validarCampos())//true = todo bien
            {
                FR.setCampos();
                respuesta = FR.EnviarDatosUsuario();

                if (respuesta == REGISTRO_EXITO)
                {
                    new MyMessageBox().Show(REGISTRO_EXITO);
                    activeForm.Close();
                    customDesing(VISTA_ARRANQUE);
                }
                else
                {
                    new MyMessageBox().Show(REGISTRO_SIN_EXITO);
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (logica.cerrarSesion()) //si selecciona si, se cerrará todo los forms y saldra de la sesion
            {
                logica.updateHistorial();
                activeForm.Close();
                cambioMenu();
                logica.vaciarDatosUsuario();

                if (logica.verificarForm())
                {
                    FormCollection fc = Application.OpenForms;
                    fc[1].Close();
                    //el FormTimer siempre va a estar en la posición 1 del FormCollection
                }
                bloquearForm();
                
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            IConsumidor consumidor = Consumidor.FromMap(logica.getDatosCliente());

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }
            if (e.CloseReason == CloseReason.TaskManagerClosing)
            {
                if (consumidor.getTipoUsuario() == 1)
                {
                    e.Cancel = true;
                    //e.Cancel = true; //NO SE CIERRA
                }
            }
            
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            DialogResult re = new MyMessageBox().Show(7);
            if( re == DialogResult.Yes)
            {
                logica.apagarEquipo();
            }
        }
    }
}
